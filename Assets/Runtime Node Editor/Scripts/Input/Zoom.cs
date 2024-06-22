using RuntimeNodeEditor.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

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
            CanvasData.CanvasScaler.scaleFactor = Scale;

            //Pan.Reset();
            Pan.UpdatePositionFromOrigin();
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
    }
}
