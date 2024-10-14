namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class StringOutputPointer : OutputPointer
    {
        public string value = "";

        public StringOutputPointer(Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = "";
        }
    }
}