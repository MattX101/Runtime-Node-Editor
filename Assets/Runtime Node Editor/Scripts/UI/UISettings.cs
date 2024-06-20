using UnityEngine;

namespace RuntimeNodeEditor.UI
{
    public static class UISettings
    {
        public const float nodeWidth = 240.0f;
        public const float headerHeight = 60.0f;
        public const float previewSize = nodeWidth;
        public const float previewImageMargin = 0.0f;
        public const float pointerPadding = 5.0f;

        public const float borderSize = 5.0f;

        public const float pointerSize = 30.0f;
        public const float inputFieldHeight = pointerSize;

        public const float sliderWidth = 150.0f, sliderHandleWidth = 20.0f;
        public const float sliderTextFieldWidth = 45.0f;

        public static Transform nodeCanvasTransform, windowSpawnParent;

        public static Texture2D pointerTexture;
    }
}
