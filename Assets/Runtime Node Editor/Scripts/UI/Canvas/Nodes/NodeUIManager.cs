using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.UI.Canvas.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private Texture2D _pointerTexture;

        [SerializeField]
        private NodeController _nodeController;

        [SerializeField]
        private GameObject _nodesObject;

        void Awake()
        {
            UISettings.nodeCanvasTransform = _parent.transform;
            UISettings.pointerTexture = _pointerTexture;
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
            _nodeController.nodeDrag.InitSpawnDrag(nodeUI, spawnDrag);
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

            if (nodeUI.inputFields != null)
                for (int i = 0; i < nodeUI.inputFields.Length; i++)
                    nodeUI.inputFields[i].text = data.Texts[i];

            if (nodeUI.buttons != null)
                for (int i = 0; i < nodeUI.buttons.Length; i++)
                    nodeUI.buttons[i].Toggle(data.Booleans[i]);

            if (nodeUI.sliders != null)
                for (int i = 0; i < nodeUI.sliders.Length; i++)
                    nodeUI.sliders[i].value = data.Values[i];

            _nodeController.nodeDrag.InitSpawnDrag(nodeUI, spawnDrag);
        }

        public byte[] Save()
        {
            List<byte> bytes = new List<byte>();

            RuntimeNodeEditor.Node.Node[] nodes = _nodesObject.GetComponentsInChildren<RuntimeNodeEditor.Node.Node>();
            Debug.Log(nodes.Length);

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
