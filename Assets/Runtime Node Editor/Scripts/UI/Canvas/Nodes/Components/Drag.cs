using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Components
{
    internal static class Drag
    {
        private static NodeUI _hover;
        private static NodeUI _selectedNodeUI;

        private static bool _dragOnSpawn;

        private static Vector3 _distanceFromMouseToNodeCenter = Vector3.zero;
        
        public static void ManageDrag()
        {
            if (UIData.TabOrWindowOpened)
                return;

            if (_dragOnSpawn)
            {
                SpawnDrag();
            }
            else
            {
                OnClick();
                OnClickRelease();

                OnHover();
                OnHoverLeave();

                if (_selectedNodeUI && CanvasData.IsDragging)
                    DragNode();
            }
        }

        public static void InitSpawnDrag(NodeUI nodeUI)
        {
            _selectedNodeUI = nodeUI;
            _dragOnSpawn = true;

            CanvasData.IsDragging = true;
        }
        private static void SpawnDrag()
        {
            DragNode();

            if (UnityEngine.Input.GetMouseButtonDown(0))
                ValidateDrop();
        }

        private static void OnClick()
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0))
                return;

            _selectedNodeUI = SelectNodeUI(Physics2D.Raycast(
                    MouseController.MouseWorldPosition,
                    Vector2.zero)
                    );

            if (!_selectedNodeUI)
                return;

            _selectedNodeUI.BlockRaycasts(false);

            CanvasData.IsDragging = true;

            _distanceFromMouseToNodeCenter = (Vector3)MouseController.MousePositionRelativeToCenter - _selectedNodeUI.rootRect.localPosition;
        }

        private static void OnClickRelease()
        {
            if (!UnityEngine.Input.GetMouseButtonUp(0))
                return;

            _distanceFromMouseToNodeCenter = Vector3.zero;

            ValidateDrop();
        }

        private static void OnHover()
        {
            NodeUI newNodeUI = SelectNodeUI(Physics2D.Raycast(
                MouseController.MouseWorldPosition,
                Vector2.zero)
                );

            if (!newNodeUI)
                return;

            if (_hover)
                _hover.SetAlpha(1.0f);

            _hover = newNodeUI;
            _hover.SetAlpha(0.5f);
        }

        private static void OnHoverLeave()
        {
            if (!_hover)
                return;

            if (SelectNodeUI(Physics2D.Raycast(MouseController.MouseWorldPosition, Vector2.zero)))
                return;

            _hover.SetAlpha(1.0f);
            _hover = null;
        }

        private static NodeUI SelectNodeUI(RaycastHit2D hit)
        {
            if (!hit.collider)
                return null;

            if (!hit.collider.gameObject.TryGetComponent(out RuntimeNodeEditor.Nodes.Node.Node node))
                return null;
            
            return node.gameObject.GetComponent<NodeUI>();
        }

        private static void Reset()
        {
            _selectedNodeUI = null;
            _dragOnSpawn = false;
        }
        
        private static void DragNode()
        {
            _selectedNodeUI.rootRect.localPosition = 
                (Vector3)MouseController.MousePositionRelativeToCenter - _distanceFromMouseToNodeCenter 
                - Pan.PositionFromOrigin / Zoom.Scale;
        }

        private static void ValidateDrop()
        {
            if (_selectedNodeUI)
                Drop();

            Reset();
        }
        private static void Drop()
        {
            _selectedNodeUI.BlockRaycasts(true);

            _dragOnSpawn = false;
            CanvasData.IsDragging = false;

            _selectedNodeUI = null;
        }
    }
}