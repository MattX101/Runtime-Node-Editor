using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static partial class Pan
    {
        private static Vector2 _lastSavedViewportMousePos;

        public static Vector2 ViewportPosition
        {
            get;
            private set;
        }

        public static void PanBackgroundGrid(float width, float height)
        {
            if (GlobalData.IsDragging || GlobalData.IsPointing)
                return;

            Vector2 viewportMousePos = MouseController.MouseViewportPosition * 2 - Vector2.one;

            if (!GlobalData.IsPanning)
            {
                _lastSavedViewportMousePos = viewportMousePos;

                return;
            }

            ViewportPosition +=
                (viewportMousePos - _lastSavedViewportMousePos) *
                GlobalData.Camera.orthographicSize *
                new Vector2(width, height) /
                (GlobalData.Camera.orthographicSize * 2);

            _lastSavedViewportMousePos = viewportMousePos;
        }

        public static void LoadViewportPan(float x, float y)
        {
            _positionFromOriginZoomed = new Vector3(x, y, 0);
        }
    }
}
