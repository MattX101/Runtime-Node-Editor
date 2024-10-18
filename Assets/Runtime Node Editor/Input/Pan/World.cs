using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static partial class Pan
    {
        private static Vector2 _lastSavedWorldMousePos;

        private static Vector3 _positionFromOriginZoomed;
        public static Vector3 PositionFromOriginZoomed
        {
            get => _positionFromOriginZoomed / CanvasData.ScalerFactor;
        }

        public static void PanNodesCanvas()
        {
            if (CanvasData.IsDragging || CanvasData.IsPointing)
                return;

            Vector2 mousePos = MouseController.MouseWorldPosition;

            if (!UnityEngine.Input.GetMouseButton(1))
            {
                CanvasData.IsPanning = false;
                _lastSavedWorldMousePos = mousePos;

                return;
            }
            CanvasData.IsPanning = true;

            CalculateWorldPan(
                Mathf.Clamp(mousePos.x - _lastSavedWorldMousePos.x, -1, 1),
                Mathf.Clamp(mousePos.y - _lastSavedWorldMousePos.y, -1, 1));

            _lastSavedWorldMousePos = mousePos;
        }

        public static int LoadNodesRectPosition(float x, float y)
        {
            CalculateWorldPan(x, y);

            return 8;
        }

        private static void CalculateWorldPan(float x, float y)
        {
            _nodesRect.position = new Vector3(
                NodesRectPosition.x + x,
                NodesRectPosition.y + y,
                NodesRectPosition.z);

            _positionFromOriginZoomed = new Vector3(
                CanvasData.Camera.pixelWidth / 2,
                CanvasData.Camera.pixelHeight / 2,
                0);
            _positionFromOriginZoomed -= CanvasData.Camera.WorldToScreenPoint(-NodesRectPosition);
        }
    }
}
