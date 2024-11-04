using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class ColorOutputPointer : OutputPointer
    {
        public Color Value = Color.black;

        public ColorOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            Value = Color.black;
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.Color;
        }
    }
}