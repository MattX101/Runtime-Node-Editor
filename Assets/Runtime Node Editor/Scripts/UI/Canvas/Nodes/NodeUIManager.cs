using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        [SerializeField]
        private GameObject _nodesObject;

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
            _nodeUISelection.ManageNodes(_camera, nodeDrag);
            nodeDrag.ManageDrag(_camera, _canvasScaler);
        }

        public void Spawn(string id)
        {
            Spawn(id, new Vector3(0, 0, 0), true);
        }

        public void Spawn(string id, Vector3 position, bool spawnDrag)
        {
            if (id.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return;
            }

            string nodeNamespace = "RuntimeNodeEditor.UI.Node.";

            Type type = Type.GetType(nodeNamespace + id);
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            NodeUI nodeUI = (NodeUI)Activator.CreateInstance(type);
            nodeDrag.InitSpawnDrag(nodeUI, spawnDrag);
            nodeUI.rootRect.localPosition = position;
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

        public byte[] Save()
        {
            List<byte> bytes = new List<byte>();

            RuntimeNodeEditor.Node.Node[] nodes = _nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Node.Node>();

            byte[] numOfNodes = BitConverter.GetBytes(nodes.Length);
            bytes.Add(numOfNodes[0]);
            bytes.Add(numOfNodes[1]);
            bytes.Add(numOfNodes[2]);
            bytes.Add(numOfNodes[3]);
            numOfNodes = null;

            if (nodes == null)
                return bytes.ToArray();

            foreach (RuntimeNodeEditor.Node.Node node in nodes)
                foreach (byte b in node.nodeUI.Save())
                    bytes.Add(b);

            return bytes.ToArray();
        }

        public void Load(NodeUILoadData data)
        {
            Spawn(data, false);
        }
    }
}
