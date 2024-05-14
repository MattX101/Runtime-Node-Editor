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

        [Header("UI Elements")]
        [SerializeField] private GameObject _inputField;

        private List<NodeUI> _nodes = new List<NodeUI>();

        void Awake()
        {
            CanvasData.inputField = _inputField;

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

            _nodes.Add((NodeUI)Activator.CreateInstance(type));
            _nodes[_nodes.Count - 1].nodeDrag.spawnDrag = spawnDrag;
            _nodes[_nodes.Count - 1].rootRect.localPosition = position;
        }

        public byte[] Save()
        {
            List<byte> bytes = new List<byte>();

            byte[] numOfNodes = BitConverter.GetBytes(_nodes.Count);
            bytes.Add(numOfNodes[0]);
            bytes.Add(numOfNodes[1]);
            bytes.Add(numOfNodes[2]);
            bytes.Add(numOfNodes[3]);
            numOfNodes = null;

            if (_nodes == null)
                return bytes.ToArray();

            foreach (NodeUI node in _nodes)
                foreach (byte b in node.Save())
                    bytes.Add(b);

            return bytes.ToArray();
        }

        public void Load(string[] ids, Vector3[] positions)
        {
            _nodes.Clear();

            for (int i = 0; i < ids.Length; i++)
                Spawn(ids[i], positions[i], false);
        }
    }
}
