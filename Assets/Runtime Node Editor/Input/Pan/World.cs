using RuntimeNodeEditor.Data;
using Utils.IO.Serialization;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static partial class Pan
    {
        private static Vector2 _lastSavedWorldMousePos;

        private static Vector3 _positionFromOriginZoomed;
        public static Vector3 PositionFromOriginZoomed
        {
            get => _positionFromOriginZoomed / GlobalData.ScalerFactor;
        }

        public static void PanNodesCanvas()
        {
            if (GlobalData.IsDragging || GlobalData.IsPointing)
                return;

            Vector2 mousePos = MouseController.MouseWorldPosition;

            if (!UnityEngine.Input.GetMouseButton(1))
            {
                GlobalData.IsPanning = false;
                _lastSavedWorldMousePos = mousePos;

                return;
            }
            GlobalData.IsPanning = true;

            CalculateWorldPan(
                Mathf.Clamp(mousePos.x - _lastSavedWorldMousePos.x, -1, 1),
                Mathf.Clamp(mousePos.y - _lastSavedWorldMousePos.y, -1, 1));

            _lastSavedWorldMousePos = mousePos;
        }

        private static void LoadWorldPan(FileReader reader)
        {
            CalculateWorldPan(
                reader.ReadFloat(), 
                reader.ReadFloat()
            );
        }

        private static void CalculateWorldPan(float x, float y)
        {
            _nodesRect.position = new Vector3(
                NodesRectPosition.x + x,
                NodesRectPosition.y + y,
                NodesRectPosition.z);

            _positionFromOriginZoomed = new Vector3(
                GlobalData.Camera.pixelWidth / 2,
                GlobalData.Camera.pixelHeight / 2,
                0);
            _positionFromOriginZoomed -= GlobalData.Camera.WorldToScreenPoint(-NodesRectPosition);
        }
    }
}
