using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class IntOutputPointer : OutputPointer
    {
        public int value = 0;

        public IntOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Int;
        }

        public override void Reset()
        {
            value = 0;

            base.Reset();
        }
    }
}