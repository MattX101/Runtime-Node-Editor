using System;

namespace RuntimeNodeEditor.Input
{
    public static class ScreenScale
    {
        public static float Scale;

        public static void CalculateScale(int screenWidth)
        {
            Scale = screenWidth / 1000.0f;
        }

        public static byte[] Save()
        {
            return BitConverter.GetBytes(Scale);
        }
    }
}