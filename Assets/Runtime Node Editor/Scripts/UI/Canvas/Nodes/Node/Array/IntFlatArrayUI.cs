using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class IntFlatArrayUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Int Flat Array");
            IntFlatArrayNode node = root.AddComponent<IntFlatArrayNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Int");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Int, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Int, PointerType.ArrayInsert, true);

            node.AddPointer(CreatePointer("Out", ValueType.Int, 0).AddComponent<IntOutputPointer>(), ValueType.Int);
        }
    }
}
