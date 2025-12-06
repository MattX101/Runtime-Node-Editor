using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer.Value
{
    public static partial class PointerValue
    {
        public static float GetFloat(OutputPointer Output)
        {
            return Output.ValueTypeIndex switch
            {
                (int)ValueType.Float => PointerAccess.GetFloat(Output.Id).Value,
                (int)ValueType.Int => PointerAccess.GetInt(Output.Id).Value,
                _ => 0.0f
            };
        }

        public static float GetFloat(InputPointer Input)
        {
            return 
                IsValid(Input) ? 
                GetFloat(Input.ConnectedOutputPointer) : 
                0.0f;
        }

        public static void GetFloat(InputPointer Input, ref float value)
        {
            value = 
                IsValid(Input) ? 
                GetFloat(Input.ConnectedOutputPointer) : 
                value;
        }
    }
}
