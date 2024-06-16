using UnityEngine;

namespace RuntimeNodeEditor.Node.Pointer
{
    public static class PointerColor
    {
        private static readonly Color _nullColor = Color.black;
        private static readonly Color _intColor = Color.red;
        private static readonly Color _floatColor = new Color(1.0f, 0.25f, 0.0f);
        private static readonly Color _vector2Color = new Color(1.0f, 0.75f, 0.0f);
        private static readonly Color _vector3Color = new Color(1.0f, 0.5f, 0.0f);
        private static readonly Color _charColor = new Color(0.25f, 0.75f, 1.0f);
        private static readonly Color _stringColor = new Color(0.0f, 0.5f, 1.0f);
        private static readonly Color _boolColor = new Color(0.375f, 0.0f, 0.75f);
        private static readonly Color _colorColor = Color.magenta;

        public static Color PickColor(ValueType valueType)
        {
            switch (valueType)
            {
                case ValueType.Int:
                    return _intColor;
                case ValueType.Float:
                    return _floatColor;
                case ValueType.Vector2:
                    return _vector2Color;
                case ValueType.Vector3:
                    return _vector3Color;
                case ValueType.Char:
                    return _charColor;
                case ValueType.String:
                    return _stringColor;
                case ValueType.Bool:
                    return _boolColor;
                case ValueType.Color:
                    return _colorColor;
                default:
                    return _nullColor;
            }
        }
    }
}
