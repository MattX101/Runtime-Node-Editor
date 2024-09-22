using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    internal static partial class PointerValue
    {
        public static Vector2 GetVector2(OutputPointer output)
        {
            return output.ValueType switch
            {
                ValueType.Vector2 => output.GetComponent<Vector2OutputPointer>().value,
                ValueType.Int => new Vector2(output.GetComponent<IntOutputPointer>().value, output.GetComponent<IntOutputPointer>().value),
                ValueType.Float => new Vector2(output.GetComponent<FloatOutputPointer>().value, output.GetComponent<FloatOutputPointer>().value),
                ValueType.Vector3 => new Vector2(output.GetComponent<Vector3OutputPointer>().value.x, output.GetComponent<Vector3OutputPointer>().value.y),
                _ => Vector2.zero
            };
        }

        public static Vector2 GetVector2(InputPointer input)
        {
            return 
                IsValid(input) ? 
                GetVector2(input.ConnectedOutputPointer) : 
                Vector2.zero;
        }
        
        public static void GetVector2(InputPointer input, ref Vector2 value)
        {
            value = 
                IsValid(input) ? 
                GetVector2(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
