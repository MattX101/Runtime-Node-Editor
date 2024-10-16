using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class FloatOutputPointer : OutputPointer
    {
        public float value = 0.0f;

        public FloatOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = 0.0f;
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.Float;
        }
    }
}