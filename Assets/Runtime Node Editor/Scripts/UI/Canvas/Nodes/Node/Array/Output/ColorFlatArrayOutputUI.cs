using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class ColorFlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Color Flat Array Output");
			ColorFlatArrayOutputNode node = root.AddComponent<ColorFlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "Color");

			node.AddPointer(CreateArrayPointer("In", ValueType.Color, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Color, PointerType.Array);
		}
	}
}
