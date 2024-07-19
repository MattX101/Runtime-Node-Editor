using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        public NodeConnectionLine Line;

        public InputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.None;
        }
    }
}
