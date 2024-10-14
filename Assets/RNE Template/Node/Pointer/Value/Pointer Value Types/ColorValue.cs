using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer.Value
{
    public static partial class PointerValue
    {
        public static Color GetColor(OutputPointer output)
        {
            return output.GetComponent<ColorOutputPointer>().value;
        }

        public static Color GetColor(InputPointer input)
        {
            return 
                IsValid(input) ? 
                GetColor(input.ConnectedOutputPointer) : 
                Color.black;
        }
        
        public static void GetColor(InputPointer input, ref Color value)
        {
            value = 
                IsValid(input) ? 
                GetColor(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
