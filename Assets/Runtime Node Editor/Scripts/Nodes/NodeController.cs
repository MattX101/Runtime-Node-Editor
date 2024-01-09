using RuntimeNodeEditor.Canvas.Data;
using RuntimeNodeEditor.RuntimeNode.Line;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.RuntimeNode
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

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
            _canvasScaler = FindObjectOfType<CanvasScaler>();
        }

        void Update()
        {
            _raycastHit2D = Physics2D.Raycast(_mousePos, Vector2.zero);

            _mousePos = Input.mousePosition;
            _mousePos = _camera.ScreenToWorldPoint(_mousePos);

            if (_raycastHit2D.collider != null)
                if (_raycastHit2D.collider.TryGetComponent<Node>(out Node node))
                    if (Input.GetMouseButtonDown(0))
                        Select(node);
                    else
                if (Input.GetMouseButtonDown(0) && _currentNode != null) Deselect();

            /*if (Input.GetKey(KeyCode.LeftControl))
                if (Input.GetKeyDown(KeyCode.C)) Copy();
                else if (Input.GetKeyDown(KeyCode.X)) Cut();
                else if (Input.GetKeyDown(KeyCode.V)) Paste();*/
            //if (Input.GetKeyDown(KeyCode.Delete)) Delete(_currentNode);
        }

        private void Select(Node node)
        {
            _previousNode = _currentNode;
            _currentNode = node;
        }
        private void Deselect()
        {
            _previousNode = _currentNode;
            _currentNode = null;
        }

        /*private void Copy()
        {
            if (_currentNode != null)
            {
                _copiedNode = _currentNode;
                _currentCopyIsCut = false;
                UndoCut();
            }
        }

        private void Cut()
        {
            if (_currentNode != null)
            {
                _copiedNode = _currentNode;
                _currentCopyIsCut = true;
            }
        }
        private void UndoCut()
        {
            if (_currentCopyIsCut)
            {
                _copiedNode = null;
                _currentCopyIsCut = false;
            }
        }

        private void Paste()
        {
            if (_copiedNode != null)
            {
                if (_currentNode != null)
                {
                    _currentNode.GetComponent<RawImage>().color = Color.white;
                    _previousNode = _currentNode;
                }

                Vector3 mousePos = GetMousePosition();

                NodeUI nodeUI = _copiedNode.Paste(new Vector3(mousePos.x, mousePos.y, 0.0f));
                nodeUI.nodeDrag.spawnDrag = true;

                Node newNode = nodeUI.node;

                if (_currentCopyIsCut)
                {
                    Delete(_copiedNode);

                    _currentNode = newNode;
                    _currentNode.GetComponent<RawImage>().color = Color.gray;

                    Copy();
                }
                else
                {
                    _currentNode = newNode;
                    _currentNode.GetComponent<RawImage>().color = Color.gray;
                }

                if (_lineController != null || newNode.inputs != null)
                    _lineController.CreateLinesOnNodePaste(newNode.inputs);
            }
        }*/

        /*private void Delete(Node node)
        {
            if (_currentNode != null)
            {
                if (!CanvasData.isPointing && !CanvasData.isDraging && !CanvasData.isPanning && !CanvasData.isScrolling)
                {
                    for (int i = 0; i < node.inputs.Count; i++)
                        node.inputs[i].DeleteConnection();
                    for (int i = 0; i < node.outputs.Count; i++)
                        node.outputs[i].DeleteConnections();

                    Destroy(node.gameObject);
                    _currentNode = null;
                }
            }
        }*/
    }
}
