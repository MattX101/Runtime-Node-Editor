using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    public static partial class Drag
    {
        private const int _modulate = 32;

        private static NodeUI _hover;
        private static NodeUI _selectedNodeUI;

        private static bool _dragOnSpawn;

        private static Vector3 _distanceFromMouseToNodeCenter = Vector3.zero;

        internal static void ManageDrag()
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
                {
                    DragNode();
                }
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
            {
                ValidateDrop();
            }
        }

        private static void DragNode()
        {
            Vector3 position =
                    (Vector3)MouseController.MousePositionRelativeToCenter
                    - _distanceFromMouseToNodeCenter
                    - Pan.PositionFromOriginZoomed;

            _selectedNodeUI.RootPosition = new Vector3(
                position.x - (position.x % _modulate),
                position.y - (position.y % _modulate),
                position.z);
        }
    }
}