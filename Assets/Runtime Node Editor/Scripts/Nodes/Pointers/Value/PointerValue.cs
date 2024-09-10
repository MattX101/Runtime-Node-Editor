using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

            int index = GetValueTypeIndex(input);

            if (_compatiableValues[index] == null)
                return false;

            foreach (ValueType value in _compatiableValues[index])
                if (output == value)
                    return true;

            return false;
        }

        private static int GetValueTypeIndex(ValueType input)
        {
            return input switch
            {
                ValueType.Int => 0,
                ValueType.Float => 1,
                ValueType.Bool => 2,
                ValueType.Char => 3,
                ValueType.String => 4,
                ValueType.Color => 5,
                ValueType.Vector2 => 6,
                ValueType.Vector3 => 7,
                _ => -1
            };
        }
        
        private static bool IsValid(InputPointer input) => input.node.IsValid(input);

        public static int GetInt(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Int => output.GetComponent<IntOutputPointer>().value,
                ValueType.Float => (int)output.GetComponent<FloatOutputPointer>().value,
                _ => 0
            };
        }
        public static int GetInt(InputPointer input)
            => IsValid(input) ? GetInt(input.connectedOutputPointer) : 0;
        public static void GetInt(InputPointer input, ref int value)
            => value = IsValid(input) ? GetInt(input.connectedOutputPointer) : value;

        public static float GetFloat(OutputPointer output)
        {
            return output.valueType switch
            {
                ValueType.Float => output.GetComponent<FloatOutputPointer>().value,
                ValueType.Int => output.GetComponent<IntOutputPointer>().value,
                _ => 0.0f
            };
        }
        public static float GetFloat(InputPointer input)
            => IsValid(input) ? GetFloat(input.connectedOutputPointer) : 0.0f;
        public static void GetFloat(InputPointer input, ref float value)
            => value = IsValid(input) ? GetFloat(input.connectedOutputPointer) : value;

        public static bool GetBool(OutputPointer output)
            => output.GetComponent<BoolOutputPointer>().value;
        public static bool GetBool(InputPointer input)
            => IsValid(input) ? GetBool(input.connectedOutputPointer) : false;
        public static void GetBool(InputPointer input, ref bool value)
            => value = IsValid(input) ? GetBool(input.connectedOutputPointer) : value;

        public static char GetChar(OutputPointer output)
            => output.GetComponent<CharOutputPointer>().value;
        public static char GetChar(InputPointer input)
            => IsValid(input) ? GetChar(input.connectedOutputPointer) : ' ';
        public static void GetChar(InputPointer input, ref char value)
            => value = IsValid(input) ? GetChar(input.connectedOutputPointer) : value;

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
        public static string GetString(InputPointer input)
            => IsValid(input) ? GetString(input.connectedOutputPointer) : "";
        public static void GetString(InputPointer input, ref string value)
            => value = IsValid(input) ? GetString(input.connectedOutputPointer) : value;

        public static Color GetColor(OutputPointer output) =>  output.GetComponent<ColorOutputPointer>().value; 
        public static Color GetColor(InputPointer input)
            => IsValid(input) ? GetColor(input.connectedOutputPointer) : Color.black;
        public static void GetColor(InputPointer input, ref Color value)
            => value = IsValid(input) ? GetColor(input.connectedOutputPointer) : value;

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
        public static Vector2 GetVector2(InputPointer input)
            => IsValid(input) ? GetVector2(input.connectedOutputPointer) : Vector2.zero;
        public static void GetVector2(InputPointer input, ref Vector2 value)
            => value = IsValid(input) ? GetVector2(input.connectedOutputPointer) : value;

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
        public static Vector3 GetVector3(InputPointer input)
            => IsValid(input) ? GetVector3(input.connectedOutputPointer) : Vector3.zero;
        public static void GetVector3(InputPointer input, ref Vector3 value)
            => value = IsValid(input) ? GetVector3(input.connectedOutputPointer) : value;
    }
}