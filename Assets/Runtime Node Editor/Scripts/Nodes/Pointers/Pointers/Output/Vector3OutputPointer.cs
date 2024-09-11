using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Vector3OutputPointer : OutputPointer
    {
        public Vector3 value = Vector3.zero;

        public Vector3OutputPointer(Node.Node node) : base(node) { }

        private protected override void ResetPointer()
        {
            value = Vector3.zero;
        }
    }
}