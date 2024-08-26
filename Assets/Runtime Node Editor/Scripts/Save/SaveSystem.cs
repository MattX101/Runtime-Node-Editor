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
        private string _saveDirectory;

        [Header("Scripts")]
        [SerializeField] private SeedManager seedManager;
        [SerializeField] private NodeExecution nodeExecution;
        [SerializeField] private NodeConnectionLines nodeConnections;

        [Header("Nodes")]
        [SerializeField]
        private GameObject nodesObject;

        private const string SaveExtension = "data";
        private readonly List<byte> _data = new();

        public void Save()
        {
            if (_saveDirectory == null)
                SaveAs();

            WriteData();
        }

        public void SaveAs()
        {
            _saveDirectory = _iOSelection.SaveFile("Save", SaveExtension);

            WriteData();
        }

        private void WriteData()
        {
            _data.Clear();
            
            _data.AddRange(seedManager.Save());
            _data.AddRange(Zoom.Save());
            _data.AddRange(Pan.Save());
            _data.AddRange(OnSave.Save(nodesObject));

            File.WriteAllBytes(_saveDirectory, _data.ToArray());
        }
        
        public void Load()
        {
            string path = _iOSelection.SelectFile(SaveExtension);

            if (path == null)
            {
                Debug.LogWarning("Save file was not opened!");

                return;
            }

            _saveDirectory = path;

            int position = 0;
            byte[] data = File.ReadAllBytes(_saveDirectory);

            seedManager.Seed = BitConverter.ToInt32(data, position);
            position += 4;
            
            position += Zoom.Load(BitConverter.ToSingle(data, position));
            
            position += Pan.LoadNodesRectPosition(BitConverter.ToSingle(data, position), BitConverter.ToSingle(data,position + 4));
            position += Pan.LoadPositionFromOrigin(BitConverter.ToSingle(data, position), BitConverter.ToSingle(data,position + 4));
            
            int numOfNodes = BitConverter.ToInt32(data,position);
            position += 4;

            if (numOfNodes == 0)
                return;

            for (int i = 0; i < numOfNodes; i++)
                position = LoadNode(position, data);

            Nodes.Node.Node[] nodes = nodesObject.GetComponentsInChildren<Nodes.Node.Node>();

            int connectionArrayLength = BitConverter.ToInt32(data, position);
            position += 4;

            nodeConnections.Reset();

            for (int i = 0; i < connectionArrayLength; i++)
            {
                byte inputConnectionType = data[position];
                position++;

                switch (inputConnectionType)
                {
                    case 0:
                        position = LoadConnection(nodes, position, data);
                        break;
                    case 1:
                        position = LoadConnections(nodes, position, data);
                        break;
                    default:
                        break;
                }
            }

            nodeConnections.UpdateLinesOnLoad();
            
            nodeExecution.Execute(nodes);
        }

        private int LoadNode(int position, byte[] data)
        {
            LoadData nodeUIData = new LoadData(data, position);
            position = nodeUIData.EndIndex;

            OnSave.Load(nodeUIData);

            return position;
        }

        private int LoadConnection(Nodes.Node.Node[] nodes, int position, byte[] data)
        {
            nodeConnections.Load(
                nodes[BitConverter.ToInt32(data, position)].inputs[data[position + 4]], 
                nodes[BitConverter.ToInt32(data, position + 5)].outputs[data[position + 9]]);
            
            return position + 10;
        }

        private int LoadConnections(Nodes.Node.Node[] nodes, int position, byte[] data)
        {
            int numOfConnections = BitConverter.ToInt32(data, position);
            position += 4;

            for (int i = 0; i < numOfConnections; i++)
            {
                nodeConnections.Load(
                    nodes[BitConverter.ToInt32(data, position)].inputs[data[position + 4]],
                    nodes[BitConverter.ToInt32(data, position + 5)].outputs[data[position + 9]]);

                position += 10;
            }

            return position;
        }
    }
}
