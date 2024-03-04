using RuntimeNodeEditor.UI.Canvas.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas
{
    public static class Zoom
    {
        public static float scale = 1.0f;

        public static CanvasScaler canvasScaler;

        public static void ZoomCanvas()
        {
            if (CanvasData.canZoom && !CanvasData.isDraging && !CanvasData.isPointing)
            {
                if (Input.mouseScrollDelta.y != 0)
                {
                    CanvasData.isScrolling = true;

                    scale = Mathf.Clamp(scale + Input.GetAxis("Mouse ScrollWheel"), 0.1f * ScreenScale.scale, 2.0f * ScreenScale.scale);
                    canvasScaler.scaleFactor = scale;

                    //Pan.Reset();
                    Pan.UpdatePositionFromOrigin();
                }
                else
                {
                    CanvasData.isScrolling = false;
                }
            }
        }

        public static void Reset()
        {
            CanvasData.isScrolling = false;

            canvasScaler.scaleFactor = 1.0f;
            scale = 1.0f;
        }
    }
}
