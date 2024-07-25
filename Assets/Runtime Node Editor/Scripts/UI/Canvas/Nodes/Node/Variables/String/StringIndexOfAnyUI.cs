using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
	internal class StringIndexOfAnyUI : NodeUI
	{
		public override void Init(string nodeId)
		{
			base.Init(nodeId);

			PopulateRoot("Index Of Any");
			StringIndexOfAnyNode node = root.AddComponent<StringIndexOfAnyNode>();

			NumOfInputs = 2;
			NumOfOutputs = 1;

			drawBodyImage = false;

			CreateNodeUI(node, NodeColor.Default, "Index Of Any");

			node.AddPointer(CreatePointer("Value", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);
			node.AddPointer(CreateArrayPointer("Characters", ValueType.Char, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char, RuntimeNodeEditor.Nodes.Pointer.Type.PointerType.Array);

			node.AddPointer(CreatePointer("Out", ValueType.Int, 0).AddComponent<IntOutputPointer>(), ValueType.Int);

			node.Elements = new NodeUIElements(2)
			{
				InputFields =
				{
					[0] = AddHalfInputField(
						node.inputs[0].gameObject.transform,
						TMP_InputField.ContentType.Standard,
						true,
						false,
						true),
					[1] = AddHalfInputField(
						node.outputs[0].gameObject.transform,
						TMP_InputField.ContentType.Standard,
						false,
						false,
						true),
				},
			};
		}
	}
}