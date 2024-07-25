using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.UI.Elements;
using TMPro;
using Utils.StringParameterExtractor;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringToCaseUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(StringParameterExtractor.ExtractBase(nodeId));

            PopulateRoot("To");
            StringToCaseNode node = root.AddComponent<StringToCaseNode>();

            NumOfLayers = 1;
            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "To");

            string[] parameters = StringParameterExtractor.ExtractParameters(nodeId);
            if (parameters == null)
            {
                parameters = new string[1]
                {
                    "0"
                };
            }

            node.AddPointer(CreatePointer("In", ValueType.String, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);

            node.AddPointer(CreatePointer("Out", ValueType.String, 1).AddComponent<StringOutputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(1, 0, 0, 1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        false,
                        false,
                        true)
                },
                Dropdowns =
                {
                    [0] = UIDropdown.Create(
                        CreateLayer("Dropdown", 0),
                        node,
                        node.cases,
                        node.cases[StringParameterExtractor.ExtractInt(parameters[0])]
                        )
                }
            };
        }
    }
}
