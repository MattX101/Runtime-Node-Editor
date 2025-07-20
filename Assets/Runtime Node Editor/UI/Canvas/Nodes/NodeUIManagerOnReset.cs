using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    internal class NodeUIManagerOnReset : MonoBehaviour
    {
        private NodeUIManager _nodeUIManager;

        private void Awake()
        {
            _nodeUIManager = FindObjectOfType<NodeUIManager>();
        }

        public void Reset()
        {
            _nodeUIManager.Reset();
        }
    }
}
