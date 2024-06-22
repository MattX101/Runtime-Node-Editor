using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer.Data
{
    public static class PointerColor
    {
        private static readonly Color NullColor = Color.black;
        private static readonly Color INTColor = Color.red;
        private static readonly Color FloatColor = new(1.0f, 0.25f, 0.0f);
        private static readonly Color Vector2Color = new(1.0f, 0.75f, 0.0f);
        private static readonly Color Vector3Color = new(1.0f, 0.5f, 0.0f);
        private static readonly Color CharColor = new(0.25f, 0.75f, 1.0f);
        private static readonly Color StringColor = new(0.0f, 0.5f, 1.0f);
        private static readonly Color BoolColor = new(0.375f, 0.0f, 0.75f);
        private static readonly Color ColorColor = Color.magenta;

        public static Color PickColor(ValueType valueType)
        {
            return valueType switch
            {
                ValueType.Int => INTColor,
                ValueType.Float => FloatColor,
                ValueType.Vector2 => Vector2Color,
                ValueType.Vector3 => Vector3Color,
                ValueType.Char => CharColor,
                ValueType.String => StringColor,
                ValueType.Bool => BoolColor,
                ValueType.Color => ColorColor,
                _ => NullColor
            };
        }
    }
}
