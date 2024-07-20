using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer.Type
{
    internal static class PointerTypeCompatibility
    {
        private static List<PointerType>[] _compatiableTypes = new List<PointerType>[]
        {
            new List<PointerType> { PointerType.Variable }, // Variable
            new List<PointerType> { PointerType.Array }, // Array
            new List<PointerType> { PointerType.Variable, PointerType.Array }, // Array insert
        };

        public static bool CheckCompatibility(PointerType input, PointerType output)
        {
            if (input == output)
                return true;

            int index = -1;
            switch (input)
            {
                case PointerType.Variable:
                    index = 0;
                    break;
                case PointerType.Array:
                    index = 1;
                    break;
                case PointerType.ArrayInsert:
                    index = 2;
                    break;
                default:
                    break;
            }

            if (_compatiableTypes[index] != null)
                foreach (PointerType type in _compatiableTypes[index])
                    if (output == type)
                        return true;

            return false;
        }
    }
}