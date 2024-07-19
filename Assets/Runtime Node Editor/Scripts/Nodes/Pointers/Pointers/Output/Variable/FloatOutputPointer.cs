using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class FloatOutputPointer : OutputPointer
    {
        public float value = 0.0f;

        public FloatOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Float;
        }

        public override void Reset()
        {
            value = 0.0f;

            base.Reset();
        }
    }
}