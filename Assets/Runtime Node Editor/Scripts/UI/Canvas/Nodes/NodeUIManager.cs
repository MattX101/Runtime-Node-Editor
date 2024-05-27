using RuntimeNodeEditor.Node.Pointer;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Codice.CM.WorkspaceServer.DataStore.WkTree.WriteWorkspaceTree;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private Texture2D _pointerTexture;

        private Camera _camera;
        private CanvasScaler _canvasScaler;

        [SerializeField]
        private NodeUISelection _nodeUISelection;
        public NodeUIDrag nodeDrag;

        void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _canvasScaler = FindObjectOfType<CanvasScaler>();

            nodeDrag = new NodeUIDrag();

            UISettings.nodeCanvasTransform = _parent.transform;
            UISettings.pointerTexture = _pointerTexture;
        }

        void Update()
        {
            _nodeUISelection.ManageNodes(_camera);
            nodeDrag.ManageDrag(_camera, _canvasScaler);
        }

        public void Spawn(string id)
        {
            Spawn(id, new Vector3(0, 0, 0), true);
        }

        public void Spawn(string id, Vector3 position, bool spawnDrag)
        {
            SpawnWithReturn(id, position, spawnDrag);
        }

        public NodeUI SpawnWithReturn(string id, Vector3 position, bool spawnDrag)
        {
            if (id.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return null;
            }

            string nodeNamespace = "RuntimeNodeEditor.UI.Node.";

            Type type = Type.GetType(nodeNamespace + id);
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            NodeUI nodeUI = (NodeUI)Activator.CreateInstance(type);
            nodeDrag.InitSpawnDrag(nodeUI, spawnDrag);
            nodeUI.rootRect.localPosition = position;

            return nodeUI;
        }

        public void Spawn(NodeUILoadData data, bool spawnDrag)
        {
            if (data.id.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return;
            }

            Type type = Type.GetType("RuntimeNodeEditor.UI.Node." + data.id);
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            NodeUI nodeUI = (NodeUI)Activator.CreateInstance(type);
            nodeUI.rootRect.localPosition = data.position;
            nodeUI.elements.SetElements(data.Texts, data.Booleans, data.Values);

            nodeDrag.InitSpawnDrag(nodeUI, spawnDrag);
        }

        public byte[] Save(GameObject nodesObject)
        {
            List<byte> bytes = new List<byte>();

            RuntimeNodeEditor.Node.Node[] nodes = nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Node.Node>();

            byte[] numOfNodes = BitConverter.GetBytes(nodes.Length);
            bytes.Add(numOfNodes[0]);
            bytes.Add(numOfNodes[1]);
            bytes.Add(numOfNodes[2]);
            bytes.Add(numOfNodes[3]);
            numOfNodes = null;

            if (nodes == null)
                return bytes.ToArray();

            foreach (RuntimeNodeEditor.Node.Node node in nodes)
            {
                foreach (byte b in node.nodeUI.SaveNodeUI())
                    bytes.Add(b);

                foreach (byte b in node.nodeUI.SaveUIElements())
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
            Spawn(data, false);
        }
    }
}
