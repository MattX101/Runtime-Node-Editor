using System;

namespace RuntimeNodeEditor.UI.Canvas
{
    public static class ScreenScale
    {
        public static float scale;

        public static void CalculateScale(int screenWidth)
        {
            scale = (float)screenWidth / 1000.0f;
        }

        public static byte[] Save()
        {
            return BitConverter.GetBytes(scale);
        }

        public static void Load()
        {
            //
        }
    }
}