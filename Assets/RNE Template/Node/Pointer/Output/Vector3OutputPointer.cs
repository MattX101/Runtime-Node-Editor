using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class Vector3OutputPointer : OutputPointer
    {
        public Vector3 Value = Vector3.zero;

        public Vector3OutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            Value = Vector3.zero;
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.Vector3;
        }
    }
}