using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class FloatFlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
		{
			base.Init(nodeId);

			PopulateRoot("Float Flat Array Output");
            FloatFlatArrayOutputNode node = root.AddComponent<FloatFlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "Float");

			node.AddPointer(CreateArrayPointer("In", ValueType.Float, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Float, PointerType.Array);
		}
	}
}
