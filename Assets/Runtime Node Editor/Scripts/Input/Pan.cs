using RuntimeNodeEditor.Data;
using System;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static class Pan
    {
        private static Vector2 _lastFrameMousePos;

        public static Vector3 Offset, PositionFromOrigin;

        public static RectTransform NodesRect;

        public static void PanCanvas(Camera camera)
        {
            Offset = Vector3.zero;

            if (CanvasData.IsDragging || CanvasData.IsPointing)
                return;

            Vector2 mousePos = MouseController.MouseWorldPosition;

            if (UnityEngine.Input.GetMouseButton(1) == false)
            {
                CanvasData.IsPanning = false;
                _lastFrameMousePos = mousePos;

                return;
            }

            CanvasData.IsPanning = true;

            float x = Mathf.Clamp(mousePos.x - _lastFrameMousePos.x, -1, 1);
            float y = Mathf.Clamp(mousePos.y - _lastFrameMousePos.y, -1, 1);

            NodesRect.position = new Vector3(
                NodesRect.position.x + x,
                NodesRect.position.y + y,
                NodesRect.position.z);

            Offset = new Vector3(x, y, 0);

            PositionFromOrigin = new Vector3(
                camera.pixelWidth / 2,
                camera.pixelHeight / 2,
                0);
            PositionFromOrigin -= camera.WorldToScreenPoint(-NodesRect.position);

            _lastFrameMousePos = mousePos;
        }

        public static void UpdatePositionFromOrigin()
        {
            PositionFromOrigin /= Zoom.Scale;
        }

        public static void Reset()
        {
            CanvasData.IsPanning = false;

            _lastFrameMousePos = Vector2.zero;

            Offset = Vector3.zero;
            PositionFromOrigin = Vector3.zero;

            NodesRect.position = new Vector3(0, 0, NodesRect.position.z);
        }

        public static byte[] Save()
        {
            byte[] x = BitConverter.GetBytes(PositionFromOrigin.x);
            byte[] y = BitConverter.GetBytes(PositionFromOrigin.y);
            byte[] z = BitConverter.GetBytes(PositionFromOrigin.z);

            byte[] bytes = new byte[12];

            for (int i = 0; i < 4; i++)
            {
                bytes[i] = x[i];
                bytes[i + 4] = y[i];
                bytes[i + 8] = z[i];
            }

            return bytes;
        }
    }
}
