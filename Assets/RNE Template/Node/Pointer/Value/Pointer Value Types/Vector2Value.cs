using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer.Value
{
    public static partial class PointerValue
    {
        public static Vector2 GetVector2(OutputPointer Output)
        {
            return Output.ValueTypeIndex switch
            {
                (int)ValueType.Vector2 => PointerAccess.GetVector2(Output.Id).Value,
                (int)ValueType.Int => new Vector2(PointerAccess.GetInt(Output.Id).Value, PointerAccess.GetInt(Output.Id).Value),
                (int)ValueType.Float => new Vector2(PointerAccess.GetFloat(Output.Id).Value, PointerAccess.GetFloat(Output.Id).Value),
                (int)ValueType.Vector3 => new Vector2(PointerAccess.GetVector3(Output.Id).Value.x, PointerAccess.GetVector3(Output.Id).Value.y),
                _ => Vector2.zero
            };
        }

        public static Vector2 GetVector2(InputPointer Input)
        {
            return 
                IsValid(Input) ? 
                GetVector2(Input.ConnectedOutputPointer) : 
                Vector2.zero;
        }
        
        public static void GetVector2(InputPointer Input, ref Vector2 value)
        {
            value = 
                IsValid(Input) ? 
                GetVector2(Input.ConnectedOutputPointer) : 
                value;
        }
    }
}
