using RuntimeNodeEditor.Data;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Input
{
    public static class Pan
    {
        // World Mouse
        private static Vector2 _lastSavedWorldMousePos;
        private static Vector2 WorldMousePos => MouseController.MouseWorldPosition;

        private static Vector3 PositionFromOrigin;
        public static Vector3 PositionFromOriginZoomed => PositionFromOrigin / CanvasData.CanvasScaler.scaleFactor;

        // Viewport Mouse
        private static Vector2 _lastSavedViewportMousePos;
        private static Vector2 ViewportMousePos => MouseController.MouseViewportPosition * 2 - Vector2.one;

        public static Vector2 ViewportPosition;

        public static RectTransform NodesRect;

        public static void PanNodesCanvas()
        {
            if (CanvasData.IsDragging || CanvasData.IsPointing)
                return;

            Vector2 mousePos = WorldMousePos;

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

        private static void CalculateWorldPan(float x, float y)
        {
            NodesRect.position = new Vector3(
                NodesRect.position.x + x,
                NodesRect.position.y + y,
                NodesRect.position.z);

            PositionFromOrigin = new Vector3(
                CanvasData.Camera.pixelWidth / 2,
                CanvasData.Camera.pixelHeight / 2,
                0);
            PositionFromOrigin -= CanvasData.Camera.WorldToScreenPoint(-NodesRect.position);
        }

        public static void PanBackgroundGrid(float width, float height)
        {
            if (CanvasData.IsDragging || CanvasData.IsPointing)
                return;

            if (!CanvasData.IsPanning)
            {
                _lastSavedViewportMousePos = ViewportMousePos;

                return;
            }

            ViewportPosition +=
                (ViewportMousePos - _lastSavedViewportMousePos) *
                CanvasData.Camera.orthographicSize *
                new Vector2(width, height) /
                (CanvasData.Camera.orthographicSize * 2);

            _lastSavedViewportMousePos = ViewportMousePos;
        }

        public static void Reset()
        {
            CanvasData.IsPanning = false;

            _lastSavedWorldMousePos = Vector2.zero;

            PositionFromOrigin = Vector3.zero;

            NodesRect.position = new Vector3(0, 0, NodesRect.position.z);
        }

        public static byte[] Save()
        {
            List<byte> data = new();
            
            data.AddRange(BitConverter.GetBytes(NodesRect.position.x / CanvasData.CanvasScaler.scaleFactor));
            data.AddRange(BitConverter.GetBytes(NodesRect.position.y / CanvasData.CanvasScaler.scaleFactor));
            
            data.AddRange(BitConverter.GetBytes(PositionFromOrigin.x));
            data.AddRange(BitConverter.GetBytes(PositionFromOrigin.y));

            return data.ToArray();
        }

        public static int LoadNodesRectPosition(float x, float y)
        { 
            CalculateWorldPan(x, y);

            return 8;
        }
        
        public static int LoadPositionFromOrigin(float x, float y)
        {
            PositionFromOrigin = new Vector3(x, y, 0);

            return 8;
        }
    }
}
