using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer
{
    public class IntOutputPointer : OutputPointer
    {
        public int value = 0;

        public IntOutputPointer(RuntimeNodeEditor.Node.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = 0;
        }
    }
}