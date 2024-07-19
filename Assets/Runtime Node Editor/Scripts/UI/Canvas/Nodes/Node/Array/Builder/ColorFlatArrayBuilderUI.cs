using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Type;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class ColorFlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Color Flat Array Builder");
            ColorFlatArrayBuilderNode node = root.AddComponent<ColorFlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Color");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Color, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Color, PointerType.ArrayInsert, true);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Color, 0).AddComponent<ColorArrayOutputPointer>(), ValueType.Color, PointerType.Array);
        }
    }
}
