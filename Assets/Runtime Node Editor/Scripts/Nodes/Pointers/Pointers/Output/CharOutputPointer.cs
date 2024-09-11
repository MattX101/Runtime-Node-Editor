namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class CharOutputPointer : OutputPointer
    {
        public char value = ' ';

        public CharOutputPointer(Node.Node node) : base(node) { }

        private protected override void ResetPointer()
        {
            value = ' ';
        }
    }
}