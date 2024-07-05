using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.UI.Elements;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class NANDUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Logic Gate");
            LogicGateNode node = root.AddComponent<LogicGateNode>();

            NumOfLayers = 1;
            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;
            interactablePreview = true;
            isInput = true;

            CreateNodeUI(node, NodeColor.LogicGate, "Logic Gate");

            node.dropdown.Context = 2;
            node.dropdown = UIDropdown.Create(CreateLayer("Dropdown", 0), node, node.gates, node.gates[node.dropdown.Context]);

            node.AddPointer(CreatePointer("In A", ValueType.Bool, 1, true).AddComponent<InputPointer>(), ValueType.Bool);
            node.AddPointer(CreatePointer("In B", ValueType.Bool, 2, true).AddComponent<InputPointer>(), ValueType.Bool);

            node.AddPointer(CreatePointer("Out", ValueType.Bool, 1).AddComponent<OutputPointer>(), ValueType.Bool);

            node.Elements = new NodeUIElements(0, 3, 0)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node.inputs[0].transform, true),
                    [1] = AddBooleanPreview(node.inputs[1].transform, true),
                    [2] = AddBooleanPreview(node.outputs[0].transform)
                }
            };
        }
    }
}
