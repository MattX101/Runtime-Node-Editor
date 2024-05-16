using RuntimeNodeEditor.UI.Node;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Node
{
    public class NodeController : MonoBehaviour
    {
        private Camera _camera;
        private CanvasScaler _canvasScaler;

        private NodeUISelection _nodeUISelection;

        public NodeUIDrag nodeDrag;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _canvasScaler = FindObjectOfType<CanvasScaler>();

            _nodeUISelection = new NodeUISelection();
            nodeDrag = new NodeUIDrag();
        }

        void Update()
        {
            _nodeUISelection.ManageNodes(_camera, nodeDrag);
            nodeDrag.ManageDrag(_camera, _canvasScaler);
        }
    }
}
