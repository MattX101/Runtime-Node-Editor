using UnityEngine;

namespace RuntimeNodeEditor.Canvas.Data
{
    public static class CanvasData
    {
        public static Vector2 canvasScale;

        public static bool canDrag = true;
        public static bool canPoint = true;

        public static bool isPointing = false;
        public static bool isDraging = false;
        public static bool isPanning = false;
        public static bool isScrolling = false;
    }
}
