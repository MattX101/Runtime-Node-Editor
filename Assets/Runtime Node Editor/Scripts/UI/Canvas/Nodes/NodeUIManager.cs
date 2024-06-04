using RuntimeNodeEditor.Node.Pointer;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        private const string _nodeNamespace = "RuntimeNodeEditor.UI.Canvas.Node.";

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
            CreateNode(id, true, new Vector3(0, 0, 0));
        }

        public void Spawn(string id, Vector3 position, bool spawnDrag)
        {
            CreateNode(id, spawnDrag, position);
        }

        public NodeUI SpawnWithReturn(string id, Vector3 position, bool spawnDrag)
        {
            return CreateNode(id, spawnDrag, position);
        }

        public void OnLoadSpawn(NodeUILoadData data, bool spawnDrag)
        {
            NodeUI nodeUI = CreateNode(data.id, spawnDrag, data.position);
            RuntimeNodeEditor.Node.Node node = nodeUI.gameObject.GetComponent<RuntimeNodeEditor.Node.Node>();

            if (node.elements == null)
                return;

            node.elements.SetElements(data.Texts, data.Booleans, data.Values);
        }

        private NodeUI CreateNode(string id, bool spawnDrag, Vector3 position)
        {
            if (id.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return null;
            }

            Type type = Type.GetType(_nodeNamespace + id);
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            GameObject nodeUIObject = new GameObject();
            NodeUI nodeUI = (NodeUI)nodeUIObject.AddComponent(type);
            nodeUI.Init(id);
            nodeDrag.InitSpawnDrag(nodeUI, spawnDrag);
            nodeUI.rootRect.localPosition = position;

            return nodeUI;
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
                NodeUI nodeUI = node.gameObject.GetComponent<NodeUI>();

                foreach (byte b in nodeUI.SaveNodeUI())
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
            OnLoadSpawn(data, false);
        }
    }
}
