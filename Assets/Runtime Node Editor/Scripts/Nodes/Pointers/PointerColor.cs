using UnityEngine;

namespace RuntimeNodeEditor.Node.Pointer
{
    public static class PointerColor
    {
        public static Color nullColor = Color.black;
        public static Color intColor = Color.red;
        public static Color floatColor = new Color(1.0f, 0.25f, 0.0f);
        public static Color vector2Color = new Color(1.0f, 0.75f, 0.0f);
        public static Color vector3Color = new Color(1.0f, 0.5f, 0.0f);
        public static Color charColor = new Color(0.25f, 0.75f, 1.0f);
        public static Color stringColor = new Color(0.0f, 0.5f, 1.0f);
        public static Color boolColor = new Color(0.375f, 0.0f, 0.75f);
        public static Color colorColor = Color.magenta;

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
