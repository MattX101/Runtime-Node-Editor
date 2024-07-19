using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class CharFlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
		{
			base.Init(nodeId);

			PopulateRoot("Char Flat Array Output");
            CharFlatArrayOutputNode node = root.AddComponent<CharFlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "Char");

			node.AddPointer(CreateArrayPointer("In", ValueType.Char, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char, PointerType.Array);
		}
	}
}
