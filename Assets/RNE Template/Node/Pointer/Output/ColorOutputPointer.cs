using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class ColorOutputPointer : OutputPointer
    {
        public Color value = Color.black;

        public ColorOutputPointer(Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = Color.black;
        }
    }
}