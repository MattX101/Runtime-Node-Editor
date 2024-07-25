using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringEndsWithUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Ends With");
            StringEndsWithNode node = root.AddComponent<StringEndsWithNode>();

            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Ends With");

            node.AddPointer(CreatePointer("Value", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);
            node.AddPointer(CreatePointer("Ends With", ValueType.Char, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char);

            node.AddPointer(CreatePointer("Out", ValueType.Bool, 0).AddComponent<BoolOutputPointer>(), ValueType.Bool);

            node.Elements = new NodeUIElements(2, 1)
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
                        node.inputs[1].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false,
                        true)
                },
                Buttons =
                {
                    [0] = AddBooleanPreview(node.outputs[0].gameObject.transform)
                }
            };
        }
    }
}