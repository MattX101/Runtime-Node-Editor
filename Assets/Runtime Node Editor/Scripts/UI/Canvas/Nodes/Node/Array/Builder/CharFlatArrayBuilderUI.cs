using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharFlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Char Flat Array Builder");
            CharFlatArrayBuilderNode node = root.AddComponent<CharFlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Char");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Char, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Char, PointerType.ArrayInsert);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Char, 0).AddComponent<CharArrayOutputPointer>(), ValueType.Char, PointerType.Array);
        }
    }
}
