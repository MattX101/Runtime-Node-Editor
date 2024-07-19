using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class StringArrayOutputPointer : OutputPointer
    {
        public string[] values = null;

        public StringArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.String;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
