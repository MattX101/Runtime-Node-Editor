using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class CharOutputPointer : OutputPointer
    {
        public char value = ' ';

        public CharOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Char;
        }

        public override void Reset()
        {
            value = ' ';

            base.Reset();
        }
    }
}