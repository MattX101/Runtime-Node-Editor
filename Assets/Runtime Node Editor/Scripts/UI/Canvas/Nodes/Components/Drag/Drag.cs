using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Components
{
    internal static partial class Drag
    {
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

        internal static void InitSpawnDrag(NodeUI nodeUI)
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
            _selectedNodeUI.RootPosition = 
                (Vector3)MouseController.MousePositionRelativeToCenter 
                - _distanceFromMouseToNodeCenter 
                - Pan.PositionFromOriginZoomed;
        }
    }
}