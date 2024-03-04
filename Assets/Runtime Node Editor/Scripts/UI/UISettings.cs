using UnityEngine;

namespace RuntimeNodeEditor.UI
{
    public static class UISettings
    {
        public static float nodeWidth = 240.0f;
        public static float headerHeight = 60.0f;
        public static float previewSize = nodeWidth;
        public static float previewImageMargin = 20.0f;

        public static float elementSpacing = 10.0f;
        public static float borderSize = 5.0f;

        public static float pointerSize = 30.0f;

        public static Transform nodeCanvasTransform, windowSpawnParent;

        public static Texture2D pointerTexture;
    }
}
