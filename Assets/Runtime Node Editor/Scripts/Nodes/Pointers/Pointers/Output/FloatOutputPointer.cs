namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class FloatOutputPointer : OutputPointer
    {
        public float value = 0.0f;

        public FloatOutputPointer(Node.Node node) : base(node) { }

        private protected override void ResetPointer()
        {
            value = 0.0f;
        }
    }
}