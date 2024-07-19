using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.UI.Elements;
using Utils.StringParameterExtractor;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharIsUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(StringParameterExtractor.ExtractBase(nodeId));

            PopulateRoot("Is Char");
            CharIsNode node = root.AddComponent<CharIsNode>();

            NumOfLayers = 1;
            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Is Char");

            string[] parameters = StringParameterExtractor.ExtractParameters(nodeId);
            if (parameters == null)
            {
                parameters = new string[1]
                {
                    "0"
                };
            }

            node.AddPointer(CreatePointer("In", ValueType.Char, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char);

            node.AddPointer(CreatePointer("Out", ValueType.Bool, 1).AddComponent<CharOutputPointer>(), ValueType.Bool);

            node.Elements = new NodeUIElements(0, 1, 0, 1)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node.outputs[0].transform)
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