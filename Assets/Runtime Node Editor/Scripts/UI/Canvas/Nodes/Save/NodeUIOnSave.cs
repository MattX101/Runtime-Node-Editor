using System;
using System.Collections.Generic;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Canvas.Node.Components;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Save
{
    public class NodeUIOnSave : MonoBehaviour
    {
        public byte[] Save(GameObject nodesObject)
        {
            List<byte> bytes = new List<byte>();

            RuntimeNodeEditor.Node.Node[] nodes = nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Node.Node>();

            if (nodes == null)
                return bytes.ToArray();
            
            byte[] numOfNodes = BitConverter.GetBytes(nodes.Length);
            bytes.Add(numOfNodes[0]);
            bytes.Add(numOfNodes[1]);
            bytes.Add(numOfNodes[2]);
            bytes.Add(numOfNodes[3]);

            foreach (RuntimeNodeEditor.Node.Node node in nodes)
            {
                foreach (byte b in node.gameObject.GetComponent<NodeUI>().SaveNodeUI())
                    bytes.Add(b);

                foreach (byte b in node.elements.Save())
                    bytes.Add(b);
            }

            foreach (byte b in SaveNodeConnections(nodes)) 
                bytes.Add(b);

            return bytes.ToArray();
        }

        private byte[] SaveNodeConnections(RuntimeNodeEditor.Node.Node[] nodes)
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
            countBytes = null;

            return bytes.ToArray();
        }

        private int FindNode(RuntimeNodeEditor.Node.Node[] nodes, RuntimeNodeEditor.Node.Node nodeToFind)
        {
            for (int i = 0; i < nodes.Length; i++)
                if (nodes[i] == nodeToFind)
                    return i;

            return -1;
        }

        private int FindPointer(RuntimeNodeEditor.Node.Node[] nodes, int nodeIndex, OutputPointer pointerToFind)
        {
            for (int i = 0; i < nodes[nodeIndex].outputs.Count; i++)
                if (nodes[nodeIndex].outputs[i] == pointerToFind)
                    return i;
            
            return -1;
        }

        public void Load(NodeUILoadData data)
        {
            NodeUI nodeUI = NodeUIFactory.CreateNode(data.id, data.position);
            RuntimeNodeEditor.Node.Node node = nodeUI.gameObject.GetComponent<RuntimeNodeEditor.Node.Node>();

            if (node.elements == null)
                return;

            node.elements.SetElements(data.Texts, data.Booleans, data.Values);
        }
    }
}