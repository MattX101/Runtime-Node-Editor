namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    public static partial class PointerValue
    {
        public static float GetFloat(OutputPointer output)
        {
            return output.ValueTypeIndex switch
            {
                (int)ValueType.Float => output.GetComponent<FloatOutputPointer>().value,
                (int)ValueType.Int => output.GetComponent<IntOutputPointer>().value,
                _ => 0.0f
            };
        }

        public static float GetFloat(InputPointer input)
        {
            return 
                IsValid(input) ? 
                GetFloat(input.ConnectedOutputPointer) : 
                0.0f;
        }

        public static void GetFloat(InputPointer input, ref float value)
        {
            value = 
                IsValid(input) ? 
                GetFloat(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
