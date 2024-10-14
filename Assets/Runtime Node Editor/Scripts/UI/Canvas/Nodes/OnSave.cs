using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Save
{
    public static class OnSave
    {
        public static byte[] Save(GameObject nodesObject)
        {
            List<byte> bytes = new();

            RuntimeNodeEditor.Node.Node.Node[] nodes = nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Node.Node.Node>();

            if (nodes == null)
            {
                return bytes.ToArray();
            }
            
            byte[] numOfNodes = BitConverter.GetBytes(nodes.Length);
            bytes.Add(numOfNodes[0]);
            bytes.Add(numOfNodes[1]);
            bytes.Add(numOfNodes[2]);
            bytes.Add(numOfNodes[3]);

            foreach (RuntimeNodeEditor.Node.Node.Node node in nodes)
            {
                bytes.AddRange(node.gameObject.GetComponent<NodeUI>().SaveNodeUI());

                if (node.Elements == null)
                {
                    node.Elements = new RuntimeNodeEditor.Node.UIFunctions.Elements.NodeUIElements();
                }
                
                bytes.AddRange(node.Elements.Save());
            }
            
            bytes.AddRange(SaveNodeConnections(nodes));

            return bytes.ToArray();
        }

        private static byte[] SaveNodeConnections(RuntimeNodeEditor.Node.Node.Node[] nodes)
        {
            List<byte> bytes = new List<byte>();

            int lengthIndex = bytes.Count;
            bytes.Add(0);
            bytes.Add(0);
            bytes.Add(0);
            bytes.Add(0);

            int count = 0;

            for (int nodeIndex = 0; nodeIndex < nodes.Length; nodeIndex++)
            {
                if (nodes[nodeIndex].inputs == null)
                    continue;

                for (int inputPointerIndex = 0; inputPointerIndex < nodes[nodeIndex].inputs.Count; inputPointerIndex++)
                {
                    SaveOutput(bytes, nodes, nodeIndex, nodes[nodeIndex].inputs[inputPointerIndex].ConnectedOutputPointer, inputPointerIndex);
                    count++;
                }
            }

            byte[] countBytes = BitConverter.GetBytes(count);
            bytes[lengthIndex    ] = countBytes[0];
            bytes[lengthIndex + 1] = countBytes[1];
            bytes[lengthIndex + 2] = countBytes[2];
            bytes[lengthIndex + 3] = countBytes[3];

            return bytes.ToArray();
        }

        private static void SaveOutput(List<byte> bytes, RuntimeNodeEditor.Node.Node.Node[] nodes, int nodeIndex, OutputPointer outputPointer, int inputPointerIndex)
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

            bytes.AddRange(BitConverter.GetBytes(nodeIndex));
            bytes.Add((byte)inputPointerIndex);

            bytes.AddRange(BitConverter.GetBytes(connectedOutputNode));
            bytes.Add((byte)connectedOutputIndex);
        }

        private static int FindNode(RuntimeNodeEditor.Node.Node.Node[] nodes, RuntimeNodeEditor.Node.Node.Node nodeToFind)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == nodeToFind)
                    return i;
            }

            return -1;
        }

        private static int FindPointer(RuntimeNodeEditor.Node.Node.Node[] nodes, int nodeIndex, OutputPointer pointerToFind)
        {
            for (int i = 0; i < nodes[nodeIndex].outputs.Count; i++)
            {
                if (nodes[nodeIndex].outputs[i] == pointerToFind)
                    return i;
            }
            
            return -1;
        }
    }
}