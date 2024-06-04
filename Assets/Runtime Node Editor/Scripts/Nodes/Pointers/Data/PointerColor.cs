using UnityEngine;

namespace RuntimeNodeEditor.Node.Pointer
{
    public static class PointerColor
    {
        public static readonly Color nullColor = Color.black;
        public static readonly Color intColor = Color.red;
        public static readonly Color floatColor = new Color(1.0f, 0.25f, 0.0f);
        public static readonly Color vector2Color = new Color(1.0f, 0.75f, 0.0f);
        public static readonly Color vector3Color = new Color(1.0f, 0.5f, 0.0f);
        public static readonly Color charColor = new Color(0.25f, 0.75f, 1.0f);
        public static readonly Color stringColor = new Color(0.0f, 0.5f, 1.0f);
        public static readonly Color boolColor = new Color(0.375f, 0.0f, 0.75f);
        public static readonly Color colorColor = Color.magenta;

        public static Color PickColor(ValueType valueType)
        {
            switch (valueType)
            {
                case ValueType.Int:
                    return intColor;
                case ValueType.Float:
                    return floatColor;
                case ValueType.Vector2:
                    return vector2Color;
                case ValueType.Vector3:
                    return vector3Color;
                case ValueType.Char:
                    return charColor;
                case ValueType.String:
                    return stringColor;
                case ValueType.Bool:
                    return boolColor;
                case ValueType.Color:
                    return colorColor;
                default:
                    return nullColor;
            }
        }
    }
}
