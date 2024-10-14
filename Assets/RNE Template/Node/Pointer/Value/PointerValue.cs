//using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    public static partial class PointerValue
    {
        /*private static List<ValueType>[] _compatiableValues = new List<ValueType>[]
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

        public static bool CheckCompatibility(int input, int output)
        {
            if (input == output)
                return true;

            //int index = GetValueTypeIndex(input);

            if (_compatiableValues[input] == null)
                return false;

            foreach (ValueType value in _compatiableValues[input])
            {
                if (output == (int)value)
                    return true;
            }

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
        }*/

        private static bool IsValid(InputPointer input)
        {
            return input.Node.IsValid(input);
        }
    }
}