namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    internal static partial class PointerValue
    {
        public static bool GetBool(OutputPointer output)
        {
            return output.GetComponent<BoolOutputPointer>().value;
        }

        public static bool GetBool(InputPointer input)
        {
            return 
                IsValid(input) ? 
                GetBool(input.ConnectedOutputPointer) : 
                false;
        }

        public static void GetBool(InputPointer input, ref bool value)
        {
            value = 
                IsValid(input) ? 
                GetBool(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
