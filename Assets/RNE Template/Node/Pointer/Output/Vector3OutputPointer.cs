using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class Vector3OutputPointer : OutputPointer
    {
        public Vector3 value = Vector3.zero;

        public Vector3OutputPointer(RuntimeNodeEditor.Node.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = Vector3.zero;
        }
    }
}