using UnityEngine;

namespace RuntimeNodeEditor.Data
{
    public static partial class GlobalData
    {
        public const float NodeWidth = 240.0f;
        public const float HeaderHeight = 60.0f;
        public const float PreviewSize = NodeWidth;
        public const float PreviewImageMargin = 0.0f;
        public const float PointerPadding = 5.0f;

        public const float BorderSize = 5.0f;

        public const float PointerSize = 30.0f;
        public const float InputFieldHeight = PointerSize;

        public const float SliderWidth = 150.0f, SliderHandleWidth = 20.0f;
        public const float SliderTextFieldWidth = 45.0f;

        public static Transform NodeSpawnTransform
        {
            get;
            internal set;
        }

        public static Transform WindowSpawnParent
        {
            get;
            internal set;
        }

        public static Texture2D PointerTexture
        {
            get;
            internal set;
        }
    }
}
