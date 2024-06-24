using System;
using System.Collections.Generic;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.UI.Canvas.Node.Components;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Save
{
    public static class OnSave
    {
        public static byte[] Save(GameObject nodesObject)
        {
            List<byte> bytes = new();

            RuntimeNodeEditor.Nodes.Node.Node[] nodes = nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Nodes.Node.Node>();

            if (nodes == null)
                return bytes.ToArray();
            
            byte[] numOfNodes = BitConverter.GetBytes(nodes.Length);
            bytes.Add(numOfNodes[0]);
            bytes.Add(numOfNodes[1]);
            bytes.Add(numOfNodes[2]);
            bytes.Add(numOfNodes[3]);

            foreach (RuntimeNodeEditor.Nodes.Node.Node node in nodes)
            {
                bytes.AddRange(node.gameObject.GetComponent<NodeUI>().SaveNodeUI());

                if (node.Elements == null)
                {
                    bytes.Add(0);
                    bytes.Add(0);
                    bytes.Add(0);
                    
                    continue;
                }
                
                bytes.AddRange(node.Elements.Save());
            }
            
            bytes.AddRange(SaveNodeConnections(nodes));

            return bytes.ToArray();
        }

        private static byte[] SaveNodeConnections(RuntimeNodeEditor.Nodes.Node.Node[] nodes)
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
                    if (nodes[nodeIndex].inputs[inputPointerIndex].connectedOutputPointer == null)
                        continue;

                    int connectedOutputNode = FindNode(
                        nodes,
                        nodes[nodeIndex].inputs[inputPointerIndex].connectedOutputPointer.node);

                    if (connectedOutputNode == -1)
                        continue;

                    int connectedOutputIndex = FindPointer(
                        nodes,
                        connectedOutputNode,
                        nodes[nodeIndex].inputs[inputPointerIndex].connectedOutputPointer);

                    if (connectedOutputIndex == -1)
                        continue;

                    count++;

                    bytes.AddRange(BitConverter.GetBytes(nodeIndex));
                    bytes.Add((byte)inputPointerIndex);

                    bytes.AddRange(BitConverter.GetBytes(connectedOutputNode));
                    bytes.Add((byte)connectedOutputIndex);
                }
            }

            byte[] countBytes = BitConverter.GetBytes(count);
            bytes[lengthIndex    ] = countBytes[0];
            bytes[lengthIndex + 1] = countBytes[1];
            bytes[lengthIndex + 2] = countBytes[2];
            bytes[lengthIndex + 3] = countBytes[3];

            return bytes.ToArray();
        }

        private static int FindNode(RuntimeNodeEditor.Nodes.Node.Node[] nodes, RuntimeNodeEditor.Nodes.Node.Node nodeToFind)
        {
            for (int i = 0; i < nodes.Length; i++)
                if (nodes[i] == nodeToFind)
                    return i;

            return -1;
        }

        private static int FindPointer(RuntimeNodeEditor.Nodes.Node.Node[] nodes, int nodeIndex, OutputPointer pointerToFind)
        {
            for (int i = 0; i < nodes[nodeIndex].outputs.Count; i++)
                if (nodes[nodeIndex].outputs[i] == pointerToFind)
                    return i;
            
            return -1;
        }

        public static void Load(LoadData data)
        {
            NodeUI nodeUI = Factory.CreateNode(data.ID, data.Position);
            RuntimeNodeEditor.Nodes.Node.Node node = nodeUI.gameObject.GetComponent<RuntimeNodeEditor.Nodes.Node.Node>();

            if (node.Elements == null)
                return;

            node.Elements.SetElements(data.Texts, data.Booleans, data.Values);
        }
    }
}