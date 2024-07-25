using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class IntFlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Int Flat Array Builder");
            IntFlatArrayBuilderNode node = root.AddComponent<IntFlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Int");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Int, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Int, PointerType.ArrayInsert);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Int, 0).AddComponent<IntArrayOutputPointer>(), ValueType.Int, PointerType.Array);
        }
    }
}
