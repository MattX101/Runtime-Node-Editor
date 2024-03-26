using RuntimeNodeEditor.UI.Canvas.Data;
using System;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private Texture2D _pointerTexture;

        [Header("UI Elements")]
        [SerializeField] private GameObject _inputField;

        void Awake()
        {
            CanvasData.inputField = _inputField;

            UISettings.nodeCanvasTransform = _parent.transform;
            UISettings.pointerTexture = _pointerTexture;
        }

        public void Spawn(string id)
        {
            string nodeNamespace = "RuntimeNodeEditor.UI.Node.";

            Type type = Type.GetType(nodeNamespace + id);

            if (type == null)
                throw new ArgumentNullException(nameof(type));
            
            NodeUI nodeUI = (NodeUI)Activator.CreateInstance(type);
            nodeUI.nodeDrag.spawnDrag = true;
        }
    }
}
