using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Data
{
    public static class CanvasData
    {
        public static Camera Camera
        {
            get;
            internal set;
        }

        public static CanvasScaler CanvasScaler
        {
            get;
            internal set;
        }

        public static float ScalerFactor
        {
            get => CanvasScaler.scaleFactor;
        }

        public static Vector2 ScalerResolution
        {
            get => CanvasScaler.referenceResolution;
        }

        public static Vector2 CanvasScale;

        public static bool CanPoint = true;

        public static bool IsPointing = false;
        public static bool IsDragging = false;
        public static bool IsPanning = false;
        public static bool IsScrolling = false;
        
        public static bool NodesCanvasIsActive
        {
            get
            {
                return IsPointing || IsDragging || IsPanning || IsScrolling;
            }
        }

        public static void SetScaleFactor(float scale)
        {
            CanvasScaler.scaleFactor = scale;
        }
    }
}
