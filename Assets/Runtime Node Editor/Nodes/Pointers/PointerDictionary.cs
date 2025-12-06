using System.Collections.Generic;

namespace RuntimeNodeEditor.Node.Pointer
{
    public static class PointerDictionary
    {
        private static Dictionary<int, OutputPointer> _pointers = new Dictionary<int, OutputPointer>();
        public static Dictionary<int, OutputPointer> Pointers => _pointers;
    }
}
