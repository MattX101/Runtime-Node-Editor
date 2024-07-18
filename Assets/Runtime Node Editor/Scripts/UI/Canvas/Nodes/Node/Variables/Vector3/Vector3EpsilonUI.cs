using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3EpsilonUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Epsilon");
            Vector3EpsilonNode node = root.AddComponent<Vector3EpsilonNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Epsilon");
            node.AddPointer(CreatePointer("Out", ValueType.Vector3, 0).AddComponent<OutputPointer>(), ValueType.Vector3);
        }
    }
}