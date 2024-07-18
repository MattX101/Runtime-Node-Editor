using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class BoolFlatArrayUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Bool Flat Array");
            BoolFlatArrayNode node = root.AddComponent<BoolFlatArrayNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Bool");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Bool, 0, true).AddComponent<InputPointer>(), ValueType.Bool, PointerType.ArrayInsert, true);

            node.AddPointer(CreatePointer("Out", ValueType.Bool, 0).AddComponent<OutputPointer>(), ValueType.Bool);
        }
    }
}
