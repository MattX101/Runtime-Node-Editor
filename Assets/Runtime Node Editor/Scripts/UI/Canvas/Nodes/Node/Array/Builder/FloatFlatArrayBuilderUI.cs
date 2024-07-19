using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class FloatFlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Float Flat Array Builder");
            FloatFlatArrayBuilderNode node = root.AddComponent<FloatFlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Float");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Float, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Float, PointerType.ArrayInsert, true);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Float, 0).AddComponent<FloatArrayOutputPointer>(), ValueType.Float, PointerType.Array);
        }
    }
}
