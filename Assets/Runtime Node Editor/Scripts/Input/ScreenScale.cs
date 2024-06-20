using System;

namespace RuntimeNodeEditor.Input
{
    public static class ScreenScale
    {
        public static float scale;

        public static void CalculateScale(int screenWidth)
        {
            scale = screenWidth / 1000.0f;
        }

        public static byte[] Save()
        {
            return BitConverter.GetBytes(scale);
        }
    }
}