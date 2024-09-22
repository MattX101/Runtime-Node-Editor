namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    internal static partial class PointerValue
    {
        public static int GetInt(OutputPointer output)
        {
            return output.ValueType switch
            {
                ValueType.Int => output.GetComponent<IntOutputPointer>().value,
                ValueType.Float => (int)output.GetComponent<FloatOutputPointer>().value,
                _ => 0
            };
        }

        public static int GetInt(InputPointer input)
        {
            return 
                IsValid(input) ? 
                GetInt(input.ConnectedOutputPointer) : 
                0;
        }

        public static void GetInt(InputPointer input, ref int value)
        {
            value = 
                IsValid(input) ? 
                GetInt(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
