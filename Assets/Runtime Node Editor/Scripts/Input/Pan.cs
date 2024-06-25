using RuntimeNodeEditor.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static class Pan
    {
        private static Vector2 _lastFrameMousePos;

        public static Vector3 Offset, PositionFromOrigin;

        public static RectTransform NodesRect;

        public static void PanCanvas()
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

            CalculatePan(x, y);

            _lastFrameMousePos = mousePos;
        }

        private static void CalculatePan(float x, float y)
        {
            NodesRect.position = new Vector3(
                NodesRect.position.x + x,
                NodesRect.position.y + y,
                NodesRect.position.z);

            Offset = new Vector3(x, y, 0);

            PositionFromOrigin = new Vector3(
                CanvasData.Camera.pixelWidth / 2,
                CanvasData.Camera.pixelHeight / 2,
                0);
            PositionFromOrigin -= CanvasData.Camera.WorldToScreenPoint(-NodesRect.position);
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
            List<byte> data = new();
            
            data.AddRange(BitConverter.GetBytes(NodesRect.position.x / Zoom.Scale));
            data.AddRange(BitConverter.GetBytes(NodesRect.position.y / Zoom.Scale));
            
            data.AddRange(BitConverter.GetBytes(Offset.x));
            data.AddRange(BitConverter.GetBytes(Offset.y));
            
            data.AddRange(BitConverter.GetBytes(PositionFromOrigin.x));
            data.AddRange(BitConverter.GetBytes(PositionFromOrigin.y));

            return data.ToArray();
        }

        public static int LoadNodesRectPosition(float x, float y)
        { 
            CalculatePan(x, y);

            return 8;
        }

        public static int LoadOffset(float x, float y)
        {
            Offset = new Vector3(x, y, 0);

            return 8;
        }
        
        public static int LoadPositionFromOrigin(float x, float y)
        {
            PositionFromOrigin = new Vector3(x, y, 0);

            return 8;
        }
    }
}
