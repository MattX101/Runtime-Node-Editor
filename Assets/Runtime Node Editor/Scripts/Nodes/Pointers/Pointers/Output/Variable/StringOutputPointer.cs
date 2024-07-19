using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class StringOutputPointer : OutputPointer
    {
        public string value = "";

        public StringOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.String;
        }

        public override void Reset()
        {
            value = "";

            base.Reset();
        }
    }
}