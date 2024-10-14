namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class IntOutputPointer : OutputPointer
    {
        public int value = 0;

        public IntOutputPointer(Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = 0;
        }
    }
}