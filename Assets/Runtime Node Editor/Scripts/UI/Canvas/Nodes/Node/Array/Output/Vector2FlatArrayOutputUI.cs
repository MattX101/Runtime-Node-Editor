using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class Vector2FlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
		{
			base.Init(nodeId);

			PopulateRoot("Vector2 Flat Array Output");
            Vector2FlatArrayOutputNode node = root.AddComponent<Vector2FlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "Vector2");

			node.AddPointer(CreateArrayPointer("In", ValueType.Vector2, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Vector2, PointerType.Array);
		}
	}
}
