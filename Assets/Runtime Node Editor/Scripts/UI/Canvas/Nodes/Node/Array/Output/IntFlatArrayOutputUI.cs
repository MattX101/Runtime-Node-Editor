using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class IntFlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Int Flat Array Output");
			IntFlatArrayOutputNode node = root.AddComponent<IntFlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "Int");

			node.AddPointer(CreateArrayPointer("In", ValueType.Int, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Int, PointerType.Array);
		}
	}
}
