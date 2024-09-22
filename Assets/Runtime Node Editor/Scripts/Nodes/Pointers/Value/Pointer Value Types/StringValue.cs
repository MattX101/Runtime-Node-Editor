namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    internal static partial class PointerValue
    {
        public static string GetString(OutputPointer output)
        {
            return output.ValueType switch
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
        {
            return 
                IsValid(input) ? 
                GetString(input.ConnectedOutputPointer) : 
                "";
        }

        public static void GetString(InputPointer input, ref string value)
        {
            value = 
                IsValid(input) ? 
                GetString(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
