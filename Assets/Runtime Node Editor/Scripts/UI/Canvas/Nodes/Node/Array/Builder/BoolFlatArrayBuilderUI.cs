using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class BoolFlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Bool Flat Array Builder");
            BoolFlatArrayBuilderNode node = root.AddComponent<BoolFlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Bool");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Bool, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Bool, PointerType.ArrayInsert);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Bool, 0).AddComponent<BoolArrayOutputPointer>(), ValueType.Bool, PointerType.Array);
        }
    }
}
