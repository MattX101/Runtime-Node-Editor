using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static class MouseController
    {
        public static Vector2 MouseWorldPosition
        {
            get
            {
                return CanvasData.Camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            }
        }

        public static Vector2 MouseViewportPosition
        {
            get
            {
                return CanvasData.Camera.ScreenToViewportPoint(UnityEngine.Input.mousePosition);
            }
        }
       
        public static Vector2 MousePositionRelativeToCenter
        {
            get
            {
                return 
                    new Vector2(
                        (MouseViewportPosition.x * CanvasData.ScalerResolution.x) - CanvasData.ScalerResolution.x / 2.0f,
                        (MouseViewportPosition.y * CanvasData.ScalerResolution.y) - CanvasData.ScalerResolution.y / 2.0f
                    ) * CanvasData.CanvasScale;
            }
        }
    }
}
