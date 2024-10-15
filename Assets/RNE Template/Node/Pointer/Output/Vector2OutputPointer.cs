using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class Vector2OutputPointer : OutputPointer
    {
        public Vector2 value = Vector2.zero;

        public Vector2OutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = Vector2.zero;
        }
    }
}