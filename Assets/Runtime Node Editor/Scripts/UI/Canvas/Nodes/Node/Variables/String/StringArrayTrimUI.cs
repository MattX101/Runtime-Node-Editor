using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.UI.Elements;
using TMPro;
using Utils.StringParameterExtractor;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringArrayTrimUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Array Trim");
            StringArrayTrimNode node = root.AddComponent<StringArrayTrimNode>();

            NumOfLayers = 1;
            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Array Trim");

            string[] parameters = StringParameterExtractor.ExtractParameters(nodeId);
            if (parameters == null)
            {
                parameters = new string[1]
                {
                    "0"
                };
            }

            node.AddPointer(CreatePointer("Value", ValueType.String, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);
            node.AddPointer(CreateArrayPointer("Characters", ValueType.Char, 2, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char, RuntimeNodeEditor.Nodes.Pointer.Type.PointerType.Array);

            node.AddPointer(CreatePointer("Out", ValueType.String, 1).AddComponent<StringOutputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(2, 0, 0, 1)
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
                Dropdowns =
                {
                    [0] = UIDropdown.Create(
                        CreateLayer("Dropdown", 0),
                        node,
                        node.trims,
                        node.trims[StringParameterExtractor.ExtractInt(parameters[0])]
                        )
                }
            };
        }
    }
}