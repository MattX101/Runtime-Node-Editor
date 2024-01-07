namespace RuntimeNodeEditor.Canvas
{
    public static class ScreenScale
    {
        public static float scale;

        public static void CalcaulteScale(int screenWidth)
        {
            scale = (float)screenWidth / 1000.0f;
        }
    }
}