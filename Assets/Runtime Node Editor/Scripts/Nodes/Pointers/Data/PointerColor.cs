using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer.Data
{
    public static class PointerColor
    {
        private static readonly Color _nullColor = Color.black;
        private static readonly Color _intColor = Color.red;
        private static readonly Color _floatColor = new(1.0f, 0.25f, 0.0f);
        private static readonly Color _vector2Color = new(1.0f, 0.75f, 0.0f);
        private static readonly Color _vector3Color = new(1.0f, 0.5f, 0.0f);
        private static readonly Color _charColor = new(0.25f, 0.75f, 1.0f);
        private static readonly Color _stringColor = new(0.0f, 0.5f, 1.0f);
        private static readonly Color _boolColor = new(0.375f, 0.0f, 0.75f);
        private static readonly Color _colorColor = Color.magenta;

        public static Color PickColor(ValueType valueType)
        {
            return valueType switch
            {
                ValueType.Int => _intColor,
                ValueType.Float => _floatColor,
                ValueType.Vector2 => _vector2Color,
                ValueType.Vector3 => _vector3Color,
                ValueType.Char => _charColor,
                ValueType.String => _stringColor,
                ValueType.Bool => _boolColor,
                ValueType.Color => _colorColor,
                _ => _nullColor
            };
        }
    }
}
