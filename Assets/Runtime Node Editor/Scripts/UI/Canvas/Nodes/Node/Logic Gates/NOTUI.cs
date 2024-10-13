using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class NOTUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("NOT");
            NOTNode node = root.AddComponent<NOTNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.LogicGate, "NOT");

            node.AddPointer(CreatePointer("In", ValueType.Bool, 0, true).AddComponent<InputPointer>(), ValueType.Bool);
            
            node.AddPointer(CreatePointer("Out", ValueType.Bool, 0).AddComponent<BoolOutputPointer>(), ValueType.Bool);

            node.Elements = new NodeUIElements(0, 2)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node, node.inputs[0].transform, true),
                    [1] = AddBooleanPreview(node, node.outputs[0].transform)
                }
            };
        }
    }
}
