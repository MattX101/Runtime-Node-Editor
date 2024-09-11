namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class BoolOutputPointer : OutputPointer
    {
        public bool value = false;

        public BoolOutputPointer(Node.Node node) : base(node) { }

        private protected override void ResetPointer()
        {
            value = false;
        }
    }
}