using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringArrayConcatUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Array Concat");
            StringArrayContactNode node = root.AddComponent<StringArrayContactNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Array Concat");

            node.AddPointer(CreateArrayPointer("In", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String, RuntimeNodeEditor.Nodes.Pointer.Type.PointerType.Array);

            node.AddPointer(CreatePointer("Out", ValueType.String, 0).AddComponent<StringOutputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        false,
                        false,
                        true),
                }
            };
        }
    }
}
