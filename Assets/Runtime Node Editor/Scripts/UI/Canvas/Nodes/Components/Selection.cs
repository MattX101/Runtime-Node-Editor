using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Nodes.Lines;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Components
{
    internal static class Selection
    {
        private static RuntimeNodeEditor.Nodes.Node.Node _currentNode, _previousNode, _copiedNode;
        private static bool _currentCopyIsCut = false;

        public static void OnUpdate(Camera camera, NodeUIManager nodeUIManager, ConnectionLines linesController)
        {
            MangeSelection(camera);
            KeyboardInput(nodeUIManager, linesController);
        }

        private static void MangeSelection(Camera camera)
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0))
                return;
            
            RaycastHit2D hit2D = Physics2D.Raycast(
                MouseController.GetMouseWorldPosition(camera),
                Vector2.zero
                );

            if (hit2D.collider)
            {
                hit2D.collider.TryGetComponent(out RuntimeNodeEditor.Nodes.Node.Node node);
                if (!node)
                    return;

                Select(node);

                return;
            }

            Deselect();
        }

        private static void KeyboardInput(NodeUIManager nodeUIManager, ConnectionLines linesController)
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftControl))
                if      (UnityEngine.Input.GetKeyDown(KeyCode.C)) Copy(false);
                else if (UnityEngine.Input.GetKeyDown(KeyCode.X)) Copy(true);
                else if (UnityEngine.Input.GetKeyDown(KeyCode.V)) Paste(nodeUIManager, linesController);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
                Delete(_currentNode);
        }

        private static void Select(RuntimeNodeEditor.Nodes.Node.Node node)
        {
            if (_currentNode)
                _currentNode.GetComponent<NodeUI>().SetPrimaryColor();

            _previousNode = _currentNode;
            _currentNode = node;
            
            _currentNode.GetComponent<NodeUI>().ToggleSelectColor();
        }
        private static void Deselect()
        {
            if (!_currentNode)
                return;

            _previousNode = _currentNode;

            _currentNode.GetComponent<NodeUI>().SetPrimaryColor();
            _currentNode = null;
        }

        private static void Copy(bool cut)
        {
            if (!_currentNode)
                return;

            _copiedNode = _currentNode;
            _currentCopyIsCut = cut;
        }

        private static void Paste(NodeUIManager nodeUIManager, ConnectionLines linesController)
        {
            if (!_copiedNode)
                return;

            NodeUI copiedNodeUI = _copiedNode.GetComponent<NodeUI>();
            NodeUI newNodeUI = nodeUIManager.SpawnWithReturn(copiedNodeUI.NodeId, copiedNodeUI.rootRect.localPosition);

            RuntimeNodeEditor.Nodes.Node.Node newNode = newNodeUI.root.GetComponent<RuntimeNodeEditor.Nodes.Node.Node>();

            newNode.elements.SetElements(_copiedNode.elements);
            linesController.Paste(_copiedNode, newNode);

            if (_currentCopyIsCut)
            {
                Delete(_copiedNode);
                _currentNode = newNode;
                Copy(false);
            }
        }

        private static void Delete(RuntimeNodeEditor.Nodes.Node.Node node)
        {
            if (!_currentNode)
                return;

            if (CanvasData.isPointing || CanvasData.isDraging || CanvasData.isPanning || CanvasData.isScrolling)
                return;

            node.DeletePointerConnections();

            Object.Destroy(node.gameObject);
            _currentNode = null;
        }
    }
}
