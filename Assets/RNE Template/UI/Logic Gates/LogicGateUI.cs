using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.UI.Elements;
using Utils.StringParameterExtractor;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public class LogicGateUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(StringParameterExtractor.ExtractBase(nodeId));

            PopulateRoot("Logic Gate");
            LogicGateNode node = root.AddComponent<LogicGateNode>();

            NumOfLayers = 1;
            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.LogicGate, "Logic Gate");

            string[] parameters = StringParameterExtractor.ExtractParameters(nodeId);
            if (parameters == null)
            {
                parameters = new string[1]
                {
                    "0"
                };
            }

            node.AddPointer(CreatePointer("In A", PointerColor.PickColor(ValueType.Bool), 1, true).AddComponent<InputPointer>(), (int)ValueType.Bool);
            node.AddPointer(CreatePointer("In B", PointerColor.PickColor(ValueType.Bool), 2, true).AddComponent<InputPointer>(), (int)ValueType.Bool);

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Bool), 1).AddComponent<BoolOutputPointer>(), (int)ValueType.Bool);

            node.Elements = new NodeUIElements(0, 3, 0, 1)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node, node.inputs[0].transform, true),
                    [1] = AddBooleanPreview(node, node.inputs[1].transform, true),
                    [2] = AddBooleanPreview(node, node.outputs[0].transform)
                },
                Dropdowns =
                {
                    [0] = UIDropdown.Create(
                        CreateLayer("Dropdown", 0), 
                        node, 
                        node.gates, 
                        node.gates[StringParameterExtractor.ExtractInt(parameters[0])]
                        )
                }
            };
        }
    }
}