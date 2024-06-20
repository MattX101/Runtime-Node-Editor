using RuntimeNodeEditor.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Input
{
    public static class Zoom
    {
        public static float scale = 1.0f;

        public static CanvasScaler canvasScaler;

        public static void ZoomCanvas()
        {
            if (!(CanvasData.canZoom && !CanvasData.isDraging && !CanvasData.isPointing))
                return;

            if (UnityEngine.Input.mouseScrollDelta.y == 0)
            {
                CanvasData.isScrolling = false;

                return;
            }

            CanvasData.isScrolling = true;

            scale = Mathf.Clamp(scale + UnityEngine.Input.GetAxis("Mouse ScrollWheel"), 0.1f * ScreenScale.scale, 2.0f * ScreenScale.scale);
            canvasScaler.scaleFactor = scale;

            //Pan.Reset();
            Pan.UpdatePositionFromOrigin();
        }

        public static void Reset()
        {
            CanvasData.isScrolling = false;

            canvasScaler.scaleFactor = 1.0f;
            scale = 1.0f;
        }

        public static byte[] Save()
        {
            return BitConverter.GetBytes(scale);
        }
    }
}
