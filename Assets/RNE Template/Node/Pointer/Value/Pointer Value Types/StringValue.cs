namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    public static partial class PointerValue
    {
        public static string GetString(OutputPointer output)
        {
            return output.ValueTypeIndex switch
            {
                (int)ValueType.String => output.GetComponent<StringOutputPointer>().value,
                (int)ValueType.Int => output.GetComponent<IntOutputPointer>().value.ToString(),
                (int)ValueType.Float => output.GetComponent<FloatOutputPointer>().value.ToString(),
                (int)ValueType.Bool => output.GetComponent<BoolOutputPointer>().value.ToString(),
                (int)ValueType.Char => output.GetComponent<CharOutputPointer>().value.ToString(),
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
