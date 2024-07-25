using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringEmptyUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Empty");
            StringEmptyNode node = root.AddComponent<StringEmptyNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Empty");

            node.AddPointer(CreatePointer("Out", ValueType.String, 0).AddComponent<StringOutputPointer>(), ValueType.String);
        }
    }
}
