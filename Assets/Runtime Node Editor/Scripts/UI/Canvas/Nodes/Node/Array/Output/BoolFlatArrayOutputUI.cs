using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class BoolFlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Bool Flat Array Output");
			BoolFlatArrayOutputNode node = root.AddComponent<BoolFlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "Bool");

			node.AddPointer(CreateArrayPointer("In", ValueType.Bool, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Bool, PointerType.Array);
		}
	}
}
