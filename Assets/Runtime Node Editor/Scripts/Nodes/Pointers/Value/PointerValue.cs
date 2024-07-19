using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    internal static class PointerValue
    {
        private static List<ValueType>[] _compatiableValues = new List<ValueType>[]
        {
            new List<ValueType> { ValueType.Float }, // int
            new List<ValueType> { ValueType.Int }, // float
            null, // bool
            null, // char
            new List<ValueType> { ValueType.Int, ValueType.Float, ValueType.Bool, ValueType.Char }, // string
            null, // color
            new List<ValueType> { ValueType.Int, ValueType.Float, ValueType.Vector3 }, // vector2
            new List<ValueType> { ValueType.Int, ValueType.Float, ValueType.Vector2 }, // vector3
        };

        public static bool CheckCompatibility(ValueType input, ValueType output)
        {
            if (input == output)
                return true;

            int index = -1;
            switch (input)
            {
                case ValueType.Int:
                    index = 0;
                    break;
                case ValueType.Float:
                    index = 1;
                    break;
                case ValueType.Bool:
                    index = 2;
                    break;
                case ValueType.Char:
                    index = 3;
                    break;
                case ValueType.String:
                    index = 4;
                    break;
                case ValueType.Color:
                    index = 5;
                    break;
                case ValueType.Vector2:
                    index = 6;
                    break;
                case ValueType.Vector3:
                    index = 7;
                    break;
                default:
                    break;
            }

            if (_compatiableValues[index] != null)
                foreach (ValueType value in _compatiableValues[index])
                    if (output == value)
                        return true;

            return false;
        }

        public static int GetInt(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Int => output.GetComponent<IntOutputPointer>().value,
                ValueType.Float => (int)output.GetComponent<FloatOutputPointer>().value,
                _ => 0
            };
        }

        public static float GetFloat(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Float => output.GetComponent<FloatOutputPointer>().value,
                ValueType.Int => output.GetComponent<IntOutputPointer>().value,
                _ => 0.0f
            };
        }

        public static bool GetBool(OutputPointer output)
        {
            return output.GetComponent<BoolOutputPointer>().value;
        }

        public static char GetChar(OutputPointer output)
        {
            return output.GetComponent<CharOutputPointer>().value;
        }

        public static string GetString(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.String => output.GetComponent<StringOutputPointer>().value,
                ValueType.Int => output.GetComponent<IntOutputPointer>().value.ToString(),
                ValueType.Float => output.GetComponent<FloatOutputPointer>().value.ToString(),
                ValueType.Bool => output.GetComponent<BoolOutputPointer>().value.ToString(),
                ValueType.Char => output.GetComponent<CharOutputPointer>().value.ToString(),
                _ => ""
            };
        }

        public static Color GetColor(OutputPointer output)
        {
            return output.GetComponent<ColorOutputPointer>().value; 
        }

        public static Vector2 GetVector2(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Vector2 => output.GetComponent<Vector2OutputPointer>().value,
                ValueType.Int => new Vector2(output.GetComponent<IntOutputPointer>().value, output.GetComponent<IntOutputPointer>().value),
                ValueType.Float => new Vector2(output.GetComponent<FloatOutputPointer>().value, output.GetComponent<FloatOutputPointer>().value),
                ValueType.Vector3 => new Vector2(output.GetComponent<Vector3OutputPointer>().value.x, output.GetComponent<Vector3OutputPointer>().value.y),
                _ => Vector2.zero
            };
        }

        public static Vector3 GetVector3(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Vector3 => output.GetComponent<Vector3OutputPointer>().value,
                ValueType.Int => new Vector3(output.GetComponent<IntOutputPointer>().value, output.GetComponent<IntOutputPointer>().value, output.GetComponent<IntOutputPointer>().value),
                ValueType.Float => new Vector3(output.GetComponent<FloatOutputPointer>().value, output.GetComponent<FloatOutputPointer>().value, output.GetComponent<FloatOutputPointer>().value),
                ValueType.Vector2 => new Vector3(output.GetComponent<Vector2OutputPointer>().value.x, output.GetComponent<Vector2OutputPointer>().value.y, 0),
                _ => Vector3.zero
            };
        }
    }
}