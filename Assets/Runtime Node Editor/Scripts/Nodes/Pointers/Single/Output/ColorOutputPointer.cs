using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class ColorOutputPointer : OutputPointer
    {
        public Color value = Color.black;

        public ColorOutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.Color;
        }

        public override void Reset()
        {
            value = Color.black;

            base.Reset();
        }
    }
}