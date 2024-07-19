using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class CharArrayOutputPointer : OutputPointer
    {
        public char[] values = null;

        public CharArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Char;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
