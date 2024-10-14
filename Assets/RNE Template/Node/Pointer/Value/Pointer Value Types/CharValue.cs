using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer.Value
{
    public static partial class PointerValue
    {
        public static char GetChar(OutputPointer output)
        {
            return output.GetComponent<CharOutputPointer>().value;
        }

        public static char GetChar(InputPointer input)
        {
            return 
                IsValid(input) ? 
                GetChar(input.ConnectedOutputPointer) : 
                ' ';
        }

        public static void GetChar(InputPointer input, ref char value)
        {
            value = 
                IsValid(input) ? 
                GetChar(input.ConnectedOutputPointer) : 
                value;
        }
    }
}
