using RuntimeNodeEditor.Data;
using System;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static class Zoom
    {
        public static float Scale = 1.0f;
        
        public static void ZoomCanvas()
        {
            if (CanvasData.IsDragging || CanvasData.IsPointing)
                return;

            if (UnityEngine.Input.mouseScrollDelta.y == 0)
            {
                CanvasData.IsScrolling = false;

                return;
            }

            CanvasData.IsScrolling = true;
             
            Scale = Mathf.Clamp(Scale + UnityEngine.Input.GetAxis("Mouse ScrollWheel"), 0.1f * ScreenScale.Scale, 2.0f * ScreenScale.Scale); 
            CalculateScale();
        }

        private static void CalculateScale()
        {
            CanvasData.CanvasScaler.scaleFactor = Scale;
        }

        public static void Reset()
        {
            CanvasData.IsScrolling = false;

            CanvasData.CanvasScaler.scaleFactor = 1.0f;
            Scale = 1.0f;
        }

        public static byte[] Save()
        {
            return BitConverter.GetBytes(Scale);
        }

        public static int Load(float scale)
        {
            Scale = scale;
            
            CalculateScale();

            return 4;
        }
    }
}
