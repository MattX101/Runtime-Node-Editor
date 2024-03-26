using RuntimeNodeEditor.UI.Canvas.Data;
using RuntimeNodeEditor.Node.Line;
using UnityEngine;
using UnityEngine.UI;
using RuntimeNodeEditor.UI.Canvas;
using RuntimeNodeEditor.UI.Node;

namespace RuntimeNodeEditor.Node
{
    public class NodeController : MonoBehaviour
    {
        private Camera _camera;
        private CanvasScaler _canvasScaler;

        [SerializeField] private Transform _parent;

        private RaycastHit2D _raycastHit2D;
        private Vector2 _mousePos;

        private Node _currentNode, _previousNode, _copiedNode;
        private bool _currentCopyIsCut = false;

        [SerializeField] private LinesController _lineController;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _canvasScaler = FindObjectOfType<CanvasScaler>();
        }

        void Update()
        {
            _raycastHit2D = Physics2D.Raycast(_mousePos, Vector2.zero);

            _mousePos = Input.mousePosition;
            _mousePos = _camera.ScreenToWorldPoint(_mousePos);

            Selection();

            if (Input.GetKey(KeyCode.LeftControl))
                if (Input.GetKeyDown(KeyCode.C)) Copy(false);
                else if (Input.GetKeyDown(KeyCode.X)) Copy(true);
                else if (Input.GetKeyDown(KeyCode.V)) Paste();

            if (Input.GetKeyDown(KeyCode.Delete))
                Delete(_currentNode);
        }

        private void Selection()
        {
            if (_raycastHit2D.collider == null)
            {
                if (Input.GetMouseButtonDown(0))
                    Deselect();
            }
            else
            {
                _raycastHit2D.collider.TryGetComponent(out Node node);
                if (node == null)
                    return;
                
                if (Input.GetMouseButtonDown(0))
                    Select(node);
            }
        }

        private void Select(Node node)
        {
            _previousNode = _currentNode;
            _currentNode = node;

            if (_previousNode != null)
                _previousNode.nodeUI.alpha = 1.0f;
            _currentNode.nodeUI.alpha = 0.5f;
        }
        private void Deselect()
        {
            if (_currentNode == null)
                return;

            _previousNode = _currentNode;
            _currentNode = null;

            _previousNode.nodeUI.alpha = 1.0f;
        }

        private void Copy(bool cut)
        {
            if (_currentNode == null)
                return;

            _copiedNode = _currentNode;
            _currentCopyIsCut = cut;
        }

        private void Paste()
        {
            if (_copiedNode == null)
                return;

            Vector3 mousePos = MouseController.GetMouseViewportPosition(_camera);

            NodeUI nodeUI = _copiedNode.Paste(new Vector3(mousePos.x, mousePos.y, 0.0f));
            nodeUI.nodeDrag.spawnDrag = true;

            Node newNode = nodeUI.root.GetComponent<Node>();

            if (_currentCopyIsCut)
            {
                Delete(_copiedNode);
                _currentNode = newNode;
                Copy(false);
            }
        }

        private void Delete(Node node)
        {
            if (_currentNode == null)
                return;

            if (CanvasData.isPointing || CanvasData.isDraging || CanvasData.isPanning || CanvasData.isScrolling)
                return;

            for (int i = 0; i < node.inputs.Count; i++)
                node.inputs[i].DeleteConnection();
            for (int i = 0; i < node.outputs.Count; i++)
                node.outputs[i].DeleteConnections();

            Destroy(node.gameObject);
            _currentNode = null;
        }
    }
}
