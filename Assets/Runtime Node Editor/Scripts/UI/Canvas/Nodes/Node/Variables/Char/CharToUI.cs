using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.UI.Elements;
using Utils.StringParameterExtractor;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharToUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(StringParameterExtractor.ExtractBase(nodeId));

            PopulateRoot("Char To");
            CharToNode node = root.AddComponent<CharToNode>();

            NumOfLayers = 1;
            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Char To");

            string[] parameters = StringParameterExtractor.ExtractParameters(nodeId);
            if (parameters == null)
            {
                parameters = new string[1]
                {
                    "0"
                };
            }

            node.AddPointer(CreatePointer("In", ValueType.Char, 1, true).AddComponent<InputPointer>(), ValueType.Char);

            node.AddPointer(CreatePointer("Out", ValueType.Char, 1).AddComponent<OutputPointer>(), ValueType.Char);

            node.Elements = new NodeUIElements(1, 0, 0, 1)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false)
                },
                Dropdowns =
                {
                    [0] = UIDropdown.Create(
                        CreateLayer("Dropdown", 0),
                        node,
                        node.checks,
                        node.checks[StringParameterExtractor.ExtractInt(parameters[0])]
                        )
                }
            };
        }
    }
}