using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.CanvasInput;
using RuntimeNodeEditor.Node.Line;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class NodeUISelection : MonoBehaviour
    {
        private RuntimeNodeEditor.Node.Node _currentNode, _previousNode, _copiedNode;
        private bool _currentCopyIsCut = false;

        [SerializeField]
        private NodeUIManager _nodeUIManager;

        [SerializeField]
        private LinesController _linesController;

        public void ManageNodes(Camera camera)
        {
            Selection(camera);

            if (Input.GetKey(KeyCode.LeftControl))
                if      (Input.GetKeyDown(KeyCode.C)) Copy(false);
                else if (Input.GetKeyDown(KeyCode.X)) Copy(true);
                else if (Input.GetKeyDown(KeyCode.V)) Paste();

            if (Input.GetKeyDown(KeyCode.Delete))
                Delete(_currentNode);
        }

        private void Selection(Camera camera)
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            RaycastHit2D hit2D = Physics2D.Raycast(
                MouseController.GetMouseWorldPosition(camera),
                Vector2.zero
                );

            if (hit2D.collider != null)
            {
                hit2D.collider.TryGetComponent(out RuntimeNodeEditor.Node.Node node);
                if (node == null)
                    return;

                Select(node);

                return;
            }

            Deselect();
        }

        private void Select(RuntimeNodeEditor.Node.Node node)
        {
            if (_currentNode != null)
                _currentNode.GetComponent<NodeUI>().SetPrimaryColor();

            _previousNode = _currentNode;
            _currentNode = node;

            _currentNode.GetComponent<NodeUI>().ToggleSelectColor();
        }
        private void Deselect()
        {
            if (_currentNode == null)
                return;

            _previousNode = _currentNode;

            _currentNode.GetComponent<NodeUI>().SetPrimaryColor();

            _currentNode = null;
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

            NodeUI copiedNodeUI = _copiedNode.GetComponent<NodeUI>();
            NodeUI newNodeUI = _nodeUIManager.SpawnWithReturn(copiedNodeUI.NodeId, copiedNodeUI.rootRect.localPosition, true);

            RuntimeNodeEditor.Node.Node newNode = newNodeUI.root.GetComponent<RuntimeNodeEditor.Node.Node>();

            newNode.elements.SetElements(_copiedNode.elements);
            _linesController.Paste(_copiedNode, newNode);

            if (_currentCopyIsCut)
            {
                Delete(_copiedNode);
                _currentNode = newNode;
                Copy(false);
            }
        }

        private void Delete(RuntimeNodeEditor.Node.Node node)
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
