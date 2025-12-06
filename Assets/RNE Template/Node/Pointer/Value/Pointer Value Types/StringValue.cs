using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer.Value
{
    public static partial class PointerValue
    {
        public static string GetString(OutputPointer Output)
        {
            return Output.ValueTypeIndex switch
            {
                (int)ValueType.String => PointerAccess.GetString(Output.Id).Value,
                (int)ValueType.Int => PointerAccess.GetColor(Output.Id).Value.ToString(),
                (int)ValueType.Float => PointerAccess.GetFloat(Output.Id).Value.ToString(),
                (int)ValueType.Bool => PointerAccess.GetBool(Output.Id).Value.ToString(),
                (int)ValueType.Char => PointerAccess.GetChar(Output.Id).Value.ToString(),
                _ => ""
            };
        }
        public static string GetString(InputPointer Input)
        {
            return 
                IsValid(Input) ? 
                GetString(Input.ConnectedOutputPointer) : 
                "";
        }

        public static void GetString(InputPointer Input, ref string value)
        {
            value = 
                IsValid(Input) ? 
                GetString(Input.ConnectedOutputPointer) : 
                value;
        }
    }
}
