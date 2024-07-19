using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class IntArrayOutputPointer : OutputPointer
    {
        public int[] values = null;

        public IntArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Int;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
