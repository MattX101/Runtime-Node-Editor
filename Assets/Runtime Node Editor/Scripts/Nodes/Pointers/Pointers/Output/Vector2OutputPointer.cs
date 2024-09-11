using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Vector2OutputPointer : OutputPointer
    {
        public Vector2 value = Vector2.zero;

        public Vector2OutputPointer(Node.Node node) : base(node) { }

        private protected override void ResetPointer()
        {
            value = Vector2.zero;
        }
    }
}