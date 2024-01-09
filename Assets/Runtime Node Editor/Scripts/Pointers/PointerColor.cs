using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode.Pointer
{
    public static class PointerColor
    {
        public static Color intColor = Color.red;
        public static Color floatColor = Color.blue;
        public static Color boolColor = Color.cyan;
        public static Color stringColor = Color.green;
        public static Color nullColor = Color.black;

        public static Color PickColor(ValueType valueType)
        {
            switch (valueType)
            {
                case ValueType.Int:
                    return intColor;
                case ValueType.Float:
                    return floatColor;
                case ValueType.Bool:
                    return boolColor;
                case ValueType.String:
                    return stringColor;
                default:
                    return nullColor;
            }
        }
    }
}
