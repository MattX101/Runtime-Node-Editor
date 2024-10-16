using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class IntOutputPointer : OutputPointer
    {
        public int value = 0;

        public IntOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = 0;
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.Int;
        }
    }
}