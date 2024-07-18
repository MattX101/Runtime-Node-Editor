using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer.Type
{
    internal static class PointerTypeCompatibility
    {
        private static List<PointerType>[] _compatiableTypes = new List<PointerType>[]
        {
            new List<PointerType> { PointerType.Single }, // single
            new List<PointerType> { PointerType.Array }, // array
            new List<PointerType> { PointerType.Single }, // array insert
        };

        public static bool CheckCompatibility(PointerType input, PointerType output)
        {
            if (input == output)
                return true;

            int index = -1;
            switch (input)
            {
                case PointerType.Single:
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