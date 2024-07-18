using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class IntMaxValueUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Int - Max Value");
            IntMaxValueNode node = root.AddComponent<IntMaxValueNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Int - Max Value");
            node.AddPointer(CreatePointer("Out", ValueType.Int, 0).AddComponent<OutputPointer>(), ValueType.Int);
        }
    }
}