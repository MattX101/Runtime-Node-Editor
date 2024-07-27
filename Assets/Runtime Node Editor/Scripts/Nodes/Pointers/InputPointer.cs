using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        public InputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.None;
        }
    }
}
