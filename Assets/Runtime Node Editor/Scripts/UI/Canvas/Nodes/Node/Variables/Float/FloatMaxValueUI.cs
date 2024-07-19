using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class FloatMaxValueUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Float - Max Value");
            FloatMaxValueNode node = root.AddComponent<FloatMaxValueNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Float - Max Value");
            node.AddPointer(CreatePointer("Out", ValueType.Float, 0).AddComponent<FloatOutputPointer>(), ValueType.Float);
        }
    }
}