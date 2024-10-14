using RuntimeNodeEditor.Node.Pointer;

namespace RNE.Template.Node.Pointer
{
    public class BoolOutputPointer : OutputPointer
    {
        public bool value = false;

        public BoolOutputPointer(RuntimeNodeEditor.Node.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = false;
        }
    }
}