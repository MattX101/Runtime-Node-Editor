using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class ANDUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("AND");
            ANDNode node = root.AddComponent<ANDNode>();

            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;
            interactablePreview = true;
            isInput = true;

            CreateNodeUI(node, NodeColor.LogicGate, "AND");

            node.AddPointer(CreatePointer("In A", ValueType.Bool, 0, true).AddComponent<InputPointer>(), ValueType.Bool);
            node.AddPointer(CreatePointer("In B", ValueType.Bool, 1, true).AddComponent<InputPointer>(), ValueType.Bool);

            node.AddPointer(CreatePointer("Out", ValueType.Bool, 0).AddComponent<OutputPointer>(), ValueType.Bool);

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
