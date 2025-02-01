using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Serialization;
using RuntimeNodeEditor.Node.Connection.Lines;
using RuntimeNodeEditor.UI.Canvas.Node.Factory.Data;
using RuntimeNodeEditor.UI.Canvas.Node.Factory;
using RuntimeNodeEditor.Input;
using Utils.IO.Serialization;
using UnityEngine;

namespace RuntimeNodeEditor.Save
{
    internal partial class SaveSystem
    {
        [SerializeField]
        private NodesList _nodesList;

        [SerializeField]
        private ConnectionLines nodeConnections;

        [SerializeField]
        private NodeExecution nodeExecution;

        [SerializeField]
        private UI.Tooltip.Window.Window onOpenWindow;

        public void Load()
        {
            Node.Node[] nodes = _nodesObject.GetComponentsInChildren<Node.Node>();

            if (nodes.Length > 0)
            {
                onOpenWindow.Create();

                return;
            }

            string path = _iOSelection.SelectSingleFile(SaveExtension);

            if (path == null)
            {
                Debug.LogWarning("Save file was not opened!");

                return;
            }

            _saveDirectory = path;

            FileReader reader = new FileReader(_saveDirectory);

            Zoom.Load(reader);
            Pan.Load(reader);

            LoadNodes(reader);
            nodes = _nodesObject.GetComponentsInChildren<Node.Node>();

            if (nodes.Length == 0)
                return;

            LoadConnections(reader, nodes);

            reader.Close();

            nodeExecution.Execute(nodes);
        }

        private void LoadNodes(FileReader reader)
        {
            int numOfNodes = reader.ReadInt();

            if (numOfNodes == 0)
                return;

            for (int i = 0; i < numOfNodes; i++)
            {
                LoadNode(reader);
            }
        }

        private void LoadNode(FileReader reader)
        {
            byte length = reader.ReadByte();

            if (length > 0)
            {
                NodesGroup group = _nodesList.NodesGroup;

                for (int i = 0; i < length - 1; i++)
                {
                    group = _nodesList.NodesGroup.GetGroup(reader.ReadByte());
                }
                GameObject nodeObject = Instantiate(group.GetNode(reader.ReadByte()), _nodesObject.transform);

                nodeObject.GetComponent<RectTransform>().localPosition =
                    new Vector3(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        0);

                OnLoad.Load(
                    nodeObject.GetComponent<Node.Node>(),
                    new LoadData(reader)
                    );
            }
        }

        private void LoadConnections(FileReader reader, Node.Node[] nodes)
        {
            int connectionArrayLength = reader.ReadInt();

            for (int i = 0; i < connectionArrayLength; i++)
            {
                LoadNodeConnection(reader, nodes);
            }
            nodeConnections.UpdateLinesOnLoad();
        }

        private void LoadNodeConnection(FileReader reader, Node.Node[] nodes)
        {
            nodeConnections.Load(
                nodes[reader.ReadInt()].Inputs[reader.ReadByte()],
                nodes[reader.ReadInt()].Outputs[reader.ReadByte()]);
        }
    }
}