using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringFlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("String Flat Array Builder");
            StringFlatArrayBuilderNode node = root.AddComponent<StringFlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "String");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.String, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.String, PointerType.ArrayInsert);

            node.AddPointer(CreateArrayPointer("Out", ValueType.String, 0).AddComponent<StringArrayOutputPointer>(), ValueType.String, PointerType.Array);
        }
    }
}
