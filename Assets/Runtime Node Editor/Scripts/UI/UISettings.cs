using UnityEngine;

namespace RuntimeNodeEditor.UI
{
    public static class UISettings
    {
        public static readonly float nodeWidth = 240.0f;
        public static readonly float headerHeight = 60.0f;
        public static readonly float previewSize = nodeWidth;
        public static readonly float previewImageMargin = 0.0f;
        public static readonly float pointerPadding = 5.0f;

        public static readonly float borderSize = 5.0f;

        public static readonly float pointerSize = 30.0f;
        public static readonly float inputFieldHeight = pointerSize;

        public static readonly float sliderWidth = 150.0f, sliderHandleWidth = 20.0f;
        public static readonly float sliderTextFieldWidth = 45.0f;

        public static Transform nodeCanvasTransform, windowSpawnParent;

        public static Texture2D pointerTexture;
    }
}
