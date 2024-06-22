using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static class MouseController
    {
        public static Vector2 MouseWorldPosition => CanvasData.Camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        public static Vector2 MouseViewportPosition => CanvasData.Camera.ScreenToViewportPoint(UnityEngine.Input.mousePosition);
        public static Vector2 MousePositionRelativeToCenter => GetMousePositionRelativeToCenter();
        
        private static Vector2 GetMousePositionRelativeToCenter()
        {
            Vector2 mousePos = MouseViewportPosition;

            mousePos.x *= CanvasData.CanvasScaler.referenceResolution.x;
            mousePos.x -= CanvasData.CanvasScaler.referenceResolution.x / 2.0f;
            mousePos.x *= CanvasData.CanvasScale.x;

            mousePos.y *= CanvasData.CanvasScaler.referenceResolution.y;
            mousePos.y -= CanvasData.CanvasScaler.referenceResolution.y / 2.0f;
            mousePos.y *= CanvasData.CanvasScale.y;

            return mousePos;
        }
    }
}
