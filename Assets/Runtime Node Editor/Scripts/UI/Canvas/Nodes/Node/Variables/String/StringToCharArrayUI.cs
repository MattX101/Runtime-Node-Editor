using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringToCharArrayUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("To Char Array");
            StringToCharArrayNode node = root.AddComponent<StringToCharArrayNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "To Char Array");

            node.AddPointer(CreatePointer("In", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Char, 0).AddComponent<CharArrayOutputPointer>(), ValueType.Char, RuntimeNodeEditor.Nodes.Pointer.Type.PointerType.Array);
        }
    }
}
