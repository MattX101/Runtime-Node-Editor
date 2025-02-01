using RuntimeNodeEditor.Node.Pointer;
using Utils.IO.Serialization;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Save
{
    public static class OnSave
    {
        public static void Save(FileWriter writer, GameObject nodesObject)
        {
            RuntimeNodeEditor.Node.Node[] nodes = nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Node.Node>();

            if (nodes == null)
            {
                writer.Write(0);

                return;
            }
            else
            {
                writer.Write(nodes.Length);

                foreach (RuntimeNodeEditor.Node.Node node in nodes)
                {
                    node.gameObject.GetComponent<NodeUI>().SaveNodeUI(writer);

                    if (node.Elements == null)
                    {
                        writer.Write(0);
                        writer.Write(0);
                        writer.Write(0);
                        writer.Write(0);
                    }
                    else
                    {
                        node.Elements.Save(writer);
                    }
                }

                SaveNodeConnections(writer, nodes);
            }
        }

        private static void SaveNodeConnections(FileWriter writer, RuntimeNodeEditor.Node.Node[] nodes)
        {
            int count = 0;

            for (int nodeIndex = 0; nodeIndex < nodes.Length; nodeIndex++)
            {
                if (nodes[nodeIndex].Inputs == null)
                    continue;

                for (int inputPointerIndex = 0; inputPointerIndex < nodes[nodeIndex].Inputs.Count; inputPointerIndex++)
                {
                    CountOutput(ref count, nodes, nodes[nodeIndex].Inputs[inputPointerIndex].ConnectedOutputPointer);
                }
            }

            writer.Write(count);

            for (int nodeIndex = 0; nodeIndex < nodes.Length; nodeIndex++)
            {
                if (nodes[nodeIndex].Inputs == null)
                    continue;

                for (int inputPointerIndex = 0; inputPointerIndex < nodes[nodeIndex].Inputs.Count; inputPointerIndex++)
                {
                    SaveOutput(writer, nodes, nodeIndex, nodes[nodeIndex].Inputs[inputPointerIndex].ConnectedOutputPointer, inputPointerIndex);
                }
            }
        }

        private static void CountOutput(ref int count, RuntimeNodeEditor.Node.Node[] nodes, OutputPointer outputPointer)
        {
            if (outputPointer == null)
                return;

            int connectedOutputNode = FindNode(nodes, outputPointer.Node);

            if (connectedOutputNode == -1)
                return;

            if (FindPointer(nodes, connectedOutputNode, outputPointer) == -1)
                return;

            count++;
        }

        private static void SaveOutput(FileWriter writer, RuntimeNodeEditor.Node.Node[] nodes, int nodeIndex, OutputPointer outputPointer, int inputPointerIndex)
        {
            if (outputPointer == null)
                return;

            int connectedOutputNode = FindNode(
                nodes,
                outputPointer.Node);

            if (connectedOutputNode == -1)
                return;

            int connectedOutputIndex = FindPointer(
                nodes,
                connectedOutputNode,
                outputPointer);

            if (connectedOutputIndex == -1)
                return;

            writer.Write(nodeIndex);
            writer.Write((byte)inputPointerIndex);

            writer.Write(connectedOutputNode);
            writer.Write((byte)connectedOutputIndex);
        }

        private static int FindNode(RuntimeNodeEditor.Node.Node[] nodes, RuntimeNodeEditor.Node.Node nodeToFind)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == nodeToFind)
                    return i;
            }

            return -1;
        }

        private static int FindPointer(RuntimeNodeEditor.Node.Node[] nodes, int nodeIndex, OutputPointer pointerToFind)
        {
            for (int i = 0; i < nodes[nodeIndex].Outputs.Count; i++)
            {
                if (nodes[nodeIndex].Outputs[i] == pointerToFind)
                    return i;
            }

            return -1;
        }
    }
}
