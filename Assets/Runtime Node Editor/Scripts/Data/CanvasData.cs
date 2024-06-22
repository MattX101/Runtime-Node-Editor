using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Data
{
    public static class CanvasData
    {
        public static Camera Camera;
        
        public static CanvasScaler CanvasScaler;
        
        public static Vector2 CanvasScale;

        public static bool CanPoint = true;

        public static bool IsPointing = false;
        public static bool IsDragging = false;
        public static bool IsPanning = false;
        public static bool IsScrolling = false;
    }
}
