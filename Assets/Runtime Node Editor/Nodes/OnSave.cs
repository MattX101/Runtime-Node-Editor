using RuntimeNodeEditor.Node.Pointer;
using Utils.IO.Serialization;
using System.Linq;

namespace RuntimeNodeEditor.Node.Save
{
    public static class OnSave
    {
        private static Node[] _nodes;

        public static void Save(FileWriter writer)
        {
            _nodes = NodeDictionary.Nodes.Values.ToArray();
            foreach (Node node in _nodes)
            {
                node.CodeToSave(writer);
            }

            SaveNodeConnections(writer);
        }

        private static void SaveNodeConnections(FileWriter writer)
        {
            int nodeConnectionsCount = 0;

            foreach (Node node in _nodes)
            {
                if (node.Inputs == null)
                {
                    continue;
                }

                foreach (InputPointer inputPointer in node.Inputs)
                {
                    CountOutput(ref nodeConnectionsCount, inputPointer.ConnectedOutputPointer);
                }
            }

            writer.Write(nodeConnectionsCount);

            int nodeIndex = 0;
            int inputPointerIndex = 0;
            foreach (Node node in _nodes)
            {
                if (node.Inputs == null)
                {
                    continue;
                }

                inputPointerIndex = 0;
                foreach (InputPointer inputPointer in node.Inputs)
                {
                    SaveOutput(writer, nodeIndex, inputPointer.ConnectedOutputPointer, inputPointerIndex);
                    inputPointerIndex++;
                }

                nodeIndex++;
            }
        }

        private static void CountOutput(ref int count, OutputPointer outputPointer)
        {
            if (outputPointer == null)
            {
                return;
            }

            int connectedOutputNode = FindNode(outputPointer.Node);
            if (connectedOutputNode == -1)
            {
                return;
            }

            if (FindPointer(connectedOutputNode, outputPointer) == -1)
            {
                return;
            }

            count++;
        }

        private static void SaveOutput(FileWriter writer, int nodeIndex, OutputPointer outputPointer, int inputPointerIndex)
        {
            if (outputPointer == null)
                return;

            int connectedOutputNode = FindNode(outputPointer.Node);
            if (connectedOutputNode == -1)
                return;

            int connectedOutputIndex = FindPointer(connectedOutputNode, outputPointer);
            if (connectedOutputIndex == -1)
                return;

            writer.Write(nodeIndex);
            writer.Write((byte)inputPointerIndex);

            writer.Write(connectedOutputNode);
            writer.Write((byte)connectedOutputIndex);
        }

        private static int FindNode(Node nodeToFind)
        {
            for (int i = 0; i < _nodes.Length; i++)
            {
                if (_nodes[i] == nodeToFind)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int FindPointer(int nodeIndex, OutputPointer pointerToFind)
        {
            for (int i = 0; i < _nodes[nodeIndex].Outputs.Count; i++)
            {
                if (_nodes[nodeIndex].Outputs[i] == pointerToFind)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
