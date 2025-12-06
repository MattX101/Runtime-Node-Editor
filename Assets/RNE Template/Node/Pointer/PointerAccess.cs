using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer
{
    /// <summary>
    /// A static class that provides functional acces to Output Pointers
    /// </summary>
    public static class PointerAccess
    {
        public static IntOutputPointer GetInt(int key)
        {
            return (IntOutputPointer)PointerDictionary.Pointers[key];
        }

        public static FloatOutputPointer GetFloat(int key)
        {
            return (FloatOutputPointer)PointerDictionary.Pointers[key];
        }

        public static Vector2OutputPointer GetVector2(int key)
        {
            return (Vector2OutputPointer)PointerDictionary.Pointers[key];
        }

        public static Vector3OutputPointer GetVector3(int key)
        {
            return (Vector3OutputPointer)PointerDictionary.Pointers[key];
        }

        public static ColorOutputPointer GetColor(int key)
        {
            return (ColorOutputPointer)PointerDictionary.Pointers[key];
        }

        public static BoolOutputPointer GetBool(int key)
        {
            return (BoolOutputPointer)PointerDictionary.Pointers[key];
        }

        public static CharOutputPointer GetChar(int key)
        {
            return (CharOutputPointer)PointerDictionary.Pointers[key];
        }

        public static StringOutputPointer GetString(int key)
        {
            return (StringOutputPointer)PointerDictionary.Pointers[key];
        }
    }
}