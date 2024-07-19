using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Vector3ArrayOutputPointer : OutputPointer
    {
        public Vector3[] values = null;

        public Vector3ArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Vector3;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
