using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class ColorArrayOutputPointer : OutputPointer
    {
        public Color[] values = null;

        public ColorArrayOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Color;
        }

        public override void Reset()
        {
            values = null;

            base.Reset();
        }
    }
}
