using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class BoolArrayOutputPointer : OutputPointer
    {
        public bool[] values = null;

        public BoolArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Bool;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
