using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class FloatEpsilonUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Float - Epsilon");
            FloatEpsilonNode node = root.AddComponent<FloatEpsilonNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Float - Epsilon");
            node.AddPointer(CreatePointer("Out", ValueType.Float, 0).AddComponent<OutputPointer>(), ValueType.Float);
        }
    }
}