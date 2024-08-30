using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class StringFlatArrayOutputUI : NodeUI
	{
		public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("String Flat Array Output");
            StringFlatArrayOutputNode node = root.AddComponent<StringFlatArrayOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Array, "String");

			node.AddPointer(CreateArrayPointer("In", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String, PointerType.Array);
		}
	}
}
