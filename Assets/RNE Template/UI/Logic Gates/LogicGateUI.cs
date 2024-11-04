using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using RuntimeNodeEditor.UI.Canvas.Node.UI;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RNE.Template.Node.Pointer;
using Utils.StringParameterExtractor;

namespace RNE.Template.UI.Node
{
    public class LogicGateUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(StringParameterExtractor.ExtractBase(nodeId));

            PopulateRoot("Logic Gate");
            LogicGateNode node = RootObject.AddComponent<LogicGateNode>();

            NumOfLayers = 1;
            NumOfInputs = 2;
            NumOfOutputs = 1;

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
                    [0] = AddBooleanPreview(node, node.Inputs[0].transform, true),
                    [1] = AddBooleanPreview(node, node.Inputs[1].transform, true),
                    [2] = AddBooleanPreview(node, node.Outputs[0].transform)
                },
                Dropdowns =
                {
                    [0] = UIDropdown.Create(
                        CreateLayer("Dropdown", 0), 
                        node, 
                        node.Gates, 
                        node.Gates[StringParameterExtractor.ExtractInt(parameters[0])]
                        )
                }
            };
        }
    }
}