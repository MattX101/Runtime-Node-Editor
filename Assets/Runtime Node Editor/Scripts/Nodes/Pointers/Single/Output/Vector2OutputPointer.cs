using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Vector2OutputPointer : OutputPointer
    {
        public Vector2 value = Vector2.zero;

        public Vector2OutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Vector2;
        }

        public override void Reset()
        {
            value = Vector2.zero;

            base.Reset();
        }
    }
}