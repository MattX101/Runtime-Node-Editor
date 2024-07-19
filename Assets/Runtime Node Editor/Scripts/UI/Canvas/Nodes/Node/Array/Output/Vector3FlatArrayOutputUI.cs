using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class Vector3FlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
		{
			base.Init(nodeId);

			PopulateRoot("Vector3 Flat Array Output");
            Vector3FlatArrayOutputNode node = root.AddComponent<Vector3FlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "Vector3");

			node.AddPointer(CreateArrayPointer("In", ValueType.Vector3, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Vector3, PointerType.Array);
		}
	}
}
