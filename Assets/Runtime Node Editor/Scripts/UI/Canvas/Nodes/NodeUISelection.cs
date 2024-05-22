using RuntimeNodeEditor.UI.Canvas.Data;
using RuntimeNodeEditor.UI.Canvas;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeUISelection : MonoBehaviour
    {
        private RuntimeNodeEditor.Node.Node _currentNode, _previousNode, _copiedNode;
        private bool _currentCopyIsCut = false;

        public void ManageNodes(Camera camera, NodeUIDrag nodeDrag)
        {
            Selection(camera);

            if (Input.GetKey(KeyCode.LeftControl))
                if      (Input.GetKeyDown(KeyCode.C)) Copy(false);
                else if (Input.GetKeyDown(KeyCode.X)) Copy(true);
                else if (Input.GetKeyDown(KeyCode.V)) Paste(camera, nodeDrag);

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
                _currentNode.nodeUI.SetPrimaryColor();

            _previousNode = _currentNode;
            _currentNode = node;

            _currentNode.nodeUI.ToggleSelectColor();
        }
        private void Deselect()
        {
            if (_currentNode == null)
                return;

            _previousNode = _currentNode;

            _currentNode.nodeUI.SetPrimaryColor();

            _currentNode = null;
        }

        private void Copy(bool cut)
        {
            if (_currentNode == null)
                return;

            _copiedNode = _currentNode;
            _currentCopyIsCut = cut;
        }

        private void Paste(Camera camera, NodeUIDrag nodeDrag)
        {
            if (_copiedNode == null)
                return;

            NodeUI nodeUI = _copiedNode.Paste(
                MouseController.GetMouseViewportPosition(camera)
                );
            nodeDrag.InitSpawnDrag(nodeUI, true);

            RuntimeNodeEditor.Node.Node newNode = nodeUI.root.GetComponent<RuntimeNodeEditor.Node.Node>();

            nodeUI.elements.SetElements(_copiedNode.nodeUI.elements);

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
