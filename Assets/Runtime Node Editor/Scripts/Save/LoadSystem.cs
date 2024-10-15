using RuntimeNodeEditor.Node.Connection.Lines;
using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Factory;
using RuntimeNodeEditor.Factory.Data;
using UnityEngine;
using System;
using System.IO;

namespace RuntimeNodeEditor.Save
{
    internal partial class SaveSystem
    {
        [SerializeField]
        private ConnectionLines nodeConnections;

        [SerializeField]
        private NodeExecution nodeExecution;

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

            LoadZoom(ref position, data);
            LoadPan(ref position, data);

            LoadNodes(ref position, data);
            Node.Node[] nodes = nodesObject.GetComponentsInChildren<Node.Node>();

            LoadConnections(ref position, nodes, data);

            nodeExecution.Execute(nodes);
        }

        private void LoadZoom(ref int position, byte[] data)
        {
            position += Zoom.Load(BitConverter.ToSingle(data, position));
        }

        private void LoadPan(ref int position, byte[] data)
        {
            position += Pan.LoadNodesRectPosition(BitConverter.ToSingle(data, position), BitConverter.ToSingle(data, position + 4));
            position += Pan.LoadPositionFromOrigin(BitConverter.ToSingle(data, position), BitConverter.ToSingle(data, position + 4));
        }

        private void LoadNodes(ref int position, byte[] data)
        {
            int numOfNodes = BitConverter.ToInt32(data, position);
            position += 4;

            if (numOfNodes == 0)
                return;

            for (int i = 0; i < numOfNodes; i++)
                LoadNode(ref position, data);
        }

        private void LoadNode(ref int position, byte[] data)
        {
            OnLoad.Load(
                new LoadData(data, ref position)
                );
        }

        private void LoadConnections(ref int position, Node.Node[] nodes, byte[] data)
        {
            int connectionArrayLength = BitConverter.ToInt32(data, position);
            position += 4;

            for (int i = 0; i < connectionArrayLength; i++)
            {
                LoadNodeConnection(ref position, nodes, data);
            }
            nodeConnections.UpdateLinesOnLoad();
        }

        private void LoadNodeConnection(ref int position, Node.Node[] nodes, byte[] data)
        {
            nodeConnections.Load(
                nodes[BitConverter.ToInt32(data, position)].inputs[data[position + 4]],
                nodes[BitConverter.ToInt32(data, position + 5)].outputs[data[position + 9]]);

            position += 10;
        }
    }
}
