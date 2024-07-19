using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Vector2ArrayOutputPointer : OutputPointer
    {
        public Vector2[] values = null;

        public Vector2ArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Vector2;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
