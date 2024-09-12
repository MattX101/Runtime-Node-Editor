using RuntimeNodeEditor.Data;
using System;

namespace RuntimeNodeEditor.Input
{
    public static class ScreenScale
    {
        public static float Scale;

        public static void CalculateScale()
        {
            Scale = CanvasData.Camera.pixelWidth / 1000.0f;
        }

        public static byte[] Save()
        {
            return BitConverter.GetBytes(Scale);
        }
    }
}