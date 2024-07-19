using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Vector3OutputPointer : OutputPointer
    {
        public Vector3 value = Vector3.zero;

        public Vector3OutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Vector3;
        }

        public override void Reset()
        {
            value = Vector3.zero;

            base.Reset();
        }
    }
}