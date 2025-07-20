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
                return GlobalData.Camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            }
        }

        public static Vector2 MouseViewportPosition
        {
            get
            {
                return GlobalData.Camera.ScreenToViewportPoint(UnityEngine.Input.mousePosition);
            }
        }
       
        public static Vector2 MousePositionRelativeToCenter
        {
            get
            {
                return 
                    new Vector2(
                        (MouseViewportPosition.x * GlobalData.ScalerResolution.x) - GlobalData.ScalerResolution.x / 2.0f,
                        (MouseViewportPosition.y * GlobalData.ScalerResolution.y) - GlobalData.ScalerResolution.y / 2.0f
                    ) * GlobalData.CanvasScale;
            }
        }
    }
}
