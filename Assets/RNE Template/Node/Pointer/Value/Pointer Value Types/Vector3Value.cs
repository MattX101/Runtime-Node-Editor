using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer.Value
{
    public static partial class PointerValue
    {
        public static Vector3 GetVector3(OutputPointer output)
        {
            return output.ValueTypeIndex switch
            {
                (int)ValueType.Vector3 => output.GetComponent<Vector3OutputPointer>().value,
                (int)ValueType.Int => new Vector3(output.GetComponent<IntOutputPointer>().value, output.GetComponent<IntOutputPointer>().value, output.GetComponent<IntOutputPointer>().value),
                (int)ValueType.Float => new Vector3(output.GetComponent<FloatOutputPointer>().value, output.GetComponent<FloatOutputPointer>().value, output.GetComponent<FloatOutputPointer>().value),
                (int)ValueType.Vector2 => new Vector3(output.GetComponent<Vector2OutputPointer>().value.x, output.GetComponent<Vector2OutputPointer>().value.y, 0),
                _ => Vector3.zero
            };
        }
        public static Vector3 GetVector3(InputPointer input)
        {
            return 
                IsValid(input) ? 
                GetVector3(input.ConnectedOutputPointer) : 
                Vector3.zero;
        }

        public static void GetVector3(InputPointer input, ref Vector3 value)
        {
            value = 
                IsValid(input) ? 
                GetVector3(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
