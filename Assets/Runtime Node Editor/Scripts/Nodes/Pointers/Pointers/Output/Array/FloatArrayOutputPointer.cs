using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class FloatArrayOutputPointer : OutputPointer
    {
        public float[] values = null;

        public FloatArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Float;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
