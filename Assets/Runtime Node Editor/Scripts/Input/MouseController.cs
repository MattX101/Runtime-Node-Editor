using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static class MouseController
    {
        public static void CheckMouse()
        {
            CanvasData.canDrag = UnityEngine.Input.GetMouseButtonUp(0);
        }

        public static Vector2 GetMouseWorldPosition(Camera camera)
        {
            return camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        }

        public static Vector2 GetMouseViewportPosition(Camera camera)
        {
            return camera.ScreenToViewportPoint(UnityEngine.Input.mousePosition);
        }

        public static Vector2 GetMousePositionRelativeToCenter(Camera camera, Vector2 resolution)
        {
            Vector2 mousePos = GetMouseViewportPosition(camera);

            mousePos.x *= resolution.x;
            mousePos.x -= resolution.x / 2.0f;
            mousePos.x *= CanvasData.canvasScale.x;

            mousePos.y *= resolution.y;
            mousePos.y -= resolution.y / 2.0f;
            mousePos.y *= CanvasData.canvasScale.y;

            return mousePos;
        }
    }
}
