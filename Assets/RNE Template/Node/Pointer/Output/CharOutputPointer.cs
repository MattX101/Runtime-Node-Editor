using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer
{
    public class CharOutputPointer : OutputPointer
    {
        public char value = ' ';

        public CharOutputPointer(RuntimeNodeEditor.Node.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = ' ';
        }
    }
}