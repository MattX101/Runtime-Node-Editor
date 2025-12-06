using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer.Value
{
    public static partial class PointerValue
    {
        public static int GetInt(OutputPointer Output)
        {
            return Output.ValueTypeIndex switch
            {
                (int)ValueType.Int => PointerAccess.GetInt(Output.Id).Value,
                (int)ValueType.Float => (int)PointerAccess.GetFloat(Output.Id).Value,
                _ => 0
            };
        }

        public static int GetInt(InputPointer Input)
        {
            return 
                IsValid(Input) ? 
                GetInt(Input.ConnectedOutputPointer) : 
                0;
        }

        public static void GetInt(InputPointer Input, ref int value)
        {
            value = 
                IsValid(Input) ? 
                GetInt(Input.ConnectedOutputPointer) : 
                value;
        }
    }
}
