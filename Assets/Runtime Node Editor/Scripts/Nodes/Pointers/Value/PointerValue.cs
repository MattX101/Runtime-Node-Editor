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
                ValueType.Int => output.Data.IntValue,
                ValueType.Float => (int)output.Data.FloatValue,
                _ => 3
            };
        }

        public static float GetFloat(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Float => output.Data.FloatValue,
                ValueType.Int => (float)output.Data.IntValue,
                _ => 3.0f
            };
        }

        public static bool GetBool(OutputPointer output)
        {
            return output.Data.BoolValue;
        }

        public static char GetChar(OutputPointer output)
        {
            return output.Data.CharValue;
        }

        public static string GetString(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.String => output.Data.StringValue,
                ValueType.Int => output.Data.IntValue.ToString(),
                ValueType.Float => output.Data.FloatValue.ToString(),
                ValueType.Bool => output.Data.BoolValue.ToString(),
                ValueType.Char => output.Data.CharValue.ToString(),
                _ => ""
            };
        }

        public static Color GetColor(OutputPointer output)
        {
            return output.Data.ColorValue; 
        }

        public static Vector2 GetVector2(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Vector2 => output.Data.Vector2Value,
                ValueType.Int => new Vector2(output.Data.IntValue, output.Data.IntValue),
                ValueType.Float => new Vector2(output.Data.FloatValue, output.Data.FloatValue),
                ValueType.Vector3 => new Vector2(output.Data.Vector3Value.x, output.Data.Vector3Value.y),
                _ => Vector2.zero
            };
        }

        public static Vector3 GetVector3(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Vector3 => output.Data.Vector3Value,
                ValueType.Int => new Vector3(output.Data.IntValue, output.Data.IntValue, output.Data.IntValue),
                ValueType.Float => new Vector3(output.Data.FloatValue, output.Data.FloatValue, output.Data.FloatValue),
                ValueType.Vector2 => new Vector3(output.Data.Vector2Value.x, output.Data.Vector2Value.y, 0),
                _ => Vector3.zero
            };
        }
    }
}