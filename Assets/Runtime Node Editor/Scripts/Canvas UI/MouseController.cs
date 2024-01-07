using UnityEngine;

namespace RuntimeNodeEditor.Canvas.Data
{
    public static class MouseController
    {
        public static void CheckMouse()
        {
            if (Input.GetMouseButtonDown(0))
                CanvasData.canDrag = false;
            else if (Input.GetMouseButtonUp(0))
                CanvasData.canDrag = true;
        }

        public static Vector2 GetMousePosition(Camera camera)
        {
            return camera.ScreenToWorldPoint(Input.mousePosition);
        }

        public static Vector2 GetMousePositionRelativeToCenter(Camera camera, Vector2 resolution)
        {
            Vector2 mousePos = GetMousePosition(camera);

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
