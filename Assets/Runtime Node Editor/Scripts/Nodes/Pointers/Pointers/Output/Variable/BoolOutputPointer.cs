using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class BoolOutputPointer : OutputPointer
    {
        public bool value = false;

        public BoolOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Bool;
        }

        public override void Reset()
        {
            value = false;

            base.Reset();
        }
    }
}