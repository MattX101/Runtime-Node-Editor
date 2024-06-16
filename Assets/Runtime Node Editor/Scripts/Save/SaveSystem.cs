using System;
using System.Collections.Generic;
using System.IO;
using RuntimeNodeEditor.CanvasInput;
using RuntimeNodeEditor.Functions.Seed;
using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Line;
using RuntimeNodeEditor.UI.Canvas.Node.Save;
using RuntimeNodeEditor.Utils.IO.Selection;
using UnityEngine;

namespace RuntimeNodeEditor.Save
{
    internal class SaveSystem : MonoBehaviour
    {
        private readonly IOSelection _iOSelection = new();
        private string _saveDirectory = null;
        
        [SerializeField]
        private Camera _camera;

        [Header("Scripts")]
        [SerializeField] private SeedManager _seedManager;
        [SerializeField] private NodeExecution _nodeExecution;
        [SerializeField] private NodeUIOnSave _nodeUIOnSave;
        [SerializeField] private LinesController _linesController;

        [Header("Nodes")]
        [SerializeField]
        private GameObject _nodesObject;

        private const string _saveExtension = "data";
        private List<byte> _data = new List<byte>();

        public void Save()
        {
            if (_saveDirectory == null)
                SaveAs();

            WriteData();
        }

        public void SaveAs()
        {
            _saveDirectory = _iOSelection.SaveFile("Save", _saveExtension);

            WriteData();
        }

        private void WriteData()
        {
            _data.Clear();

            foreach (byte b in _seedManager.Save()) _data.Add(b);
            foreach (byte b in Zoom.Save()) _data.Add(b);
            foreach (byte b in _nodeUIOnSave.Save(_nodesObject)) _data.Add(b);

            File.WriteAllBytes(_saveDirectory, _data.ToArray());
        }
        
        public void Load()
        {
            string path = _iOSelection.SelectFile(_saveExtension);

            if (path == null)
            {
                Debug.LogWarning("Save file was not opened!");

                return;
            }

            int position = 0;
            byte[] data = File.ReadAllBytes(path);

            _seedManager.seed = BitConverter.ToInt32(data, position);
            Zoom.scale = BitConverter.ToSingle(data, position + 4);
            int numOfNodes = BitConverter.ToInt32(data, position + 8);
            position += 12;

            if (numOfNodes == 0)
                return;

            for (int i = 0; i < numOfNodes; i++)
                position = LoadNodes(position, data);

            RuntimeNodeEditor.Node.Node[] nodes = _nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Node.Node>();

            int connectionArrayLength = BitConverter.ToInt32(data, position);
            position += 4;

            for (int i = 0; i < connectionArrayLength; i++)
                position = LoadConnections(nodes, position, data);

            _nodeExecution.Execute(nodes);
        }

        private int LoadNodes(int position, byte[] data)
        {
            NodeUILoadData nodeUIData = new NodeUILoadData(data, position);
            position = nodeUIData.endIndex;

            _nodeUIOnSave.Load(nodeUIData);

            return position;
        }

        private int LoadConnections(RuntimeNodeEditor.Node.Node[] nodes, int position, byte[] data)
        {
            _linesController.Load(
                nodes[BitConverter.ToInt32(data, position)].inputs[data[position + 4]], 
                nodes[BitConverter.ToInt32(data, position + 5)].outputs[data[position + 9]]);

            return position += 10;
        }
    }
}
