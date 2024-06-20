using System;
using System.Collections.Generic;
using System.IO;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Functions.Seed;
using RuntimeNodeEditor.Nodes;
using RuntimeNodeEditor.Nodes.Lines;
using RuntimeNodeEditor.UI.Canvas.Nodes.Save;
using Utils.IO.Selection;
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
        [SerializeField] private ConnectionLines _linesController;

        [Header("Nodes")]
        [SerializeField]
        private GameObject _nodesObject;

        private const string _saveExtension = "data";
        private readonly List<byte> _data = new List<byte>();

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
            
            _data.AddRange(_seedManager.Save());
            _data.AddRange(Zoom.Save());
            _data.AddRange(OnSave.Save(_nodesObject));

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
            Zoom.scale = BitConverter.ToSingle(data,4);
            int numOfNodes = BitConverter.ToInt32(data,8);
            position += 12;

            if (numOfNodes == 0)
                return;

            for (int i = 0; i < numOfNodes; i++)
                position = LoadNodes(position, data);

            Nodes.Node.Node[] nodes = _nodesObject.GetComponentsInChildren<Nodes.Node.Node>();

            int connectionArrayLength = BitConverter.ToInt32(data, position);
            position += 4;

            for (int i = 0; i < connectionArrayLength; i++)
                position = LoadConnections(nodes, position, data);

            _nodeExecution.Execute(nodes);
        }

        private int LoadNodes(int position, byte[] data)
        {
            LoadData nodeUIData = new LoadData(data, position);
            position = nodeUIData.endIndex;

            OnSave.Load(nodeUIData);

            return position;
        }

        private int LoadConnections(Nodes.Node.Node[] nodes, int position, byte[] data)
        {
            _linesController.Load(
                nodes[BitConverter.ToInt32(data, position)].inputs[data[position + 4]], 
                nodes[BitConverter.ToInt32(data, position + 5)].outputs[data[position + 9]]);

            return position += 10;
        }
    }
}
