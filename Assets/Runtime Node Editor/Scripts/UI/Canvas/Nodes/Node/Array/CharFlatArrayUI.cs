using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharFlatArrayUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Char Flat Array");
            CharFlatArrayNode node = root.AddComponent<CharFlatArrayNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Char");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Char, 0, true).AddComponent<InputPointer>(), ValueType.Char, true);

            node.AddPointer(CreatePointer("Out", ValueType.Char, 0).AddComponent<OutputPointer>(), ValueType.Char);
        }
    }
}
