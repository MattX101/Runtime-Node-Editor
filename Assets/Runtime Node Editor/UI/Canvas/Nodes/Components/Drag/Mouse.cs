using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    public static partial class Drag
    {
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

            GlobalData.IsDragging = true;

            _distanceFromMouseToNodeCenter =
                (Vector3)MouseController.MousePositionRelativeToCenter
                - _selectedNodeUI.RootPosition
                - Pan.PositionFromOriginZoomed;
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
            NodeUI NodeUI = SelectNodeUI(Physics2D.Raycast(
                MouseController.MouseWorldPosition,
                Vector2.zero)
                );

            if (!NodeUI)
                return;

            if (_hover)
            {
                _hover.SetAlpha(1.0f);
            }

            _hover = NodeUI;
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

            return hit.collider.GetComponent<NodeUI>();
        }
    }
}
