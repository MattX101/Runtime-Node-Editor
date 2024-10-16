using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class BoolOutputPointer : OutputPointer
    {
        public bool value = false;

        public BoolOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = false;
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.Bool;
        }
    }
}