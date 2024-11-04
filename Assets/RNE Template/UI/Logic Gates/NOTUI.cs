using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RNE.Template.Node.Pointer;

namespace RNE.Template.UI.Node
{
    public class NOTUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("NOT");
            NOTNode node = RootObject.AddComponent<NOTNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            CreateNodeUI(node, NodeColor.LogicGate, "NOT");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.Bool), 0, true).AddComponent<InputPointer>(), (int)ValueType.Bool);
            
            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Bool), 0).AddComponent<BoolOutputPointer>(), (int)ValueType.Bool);

            node.Elements = new NodeUIElements(0, 2)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node, node.Inputs[0].transform, true),
                    [1] = AddBooleanPreview(node, node.Outputs[0].transform)
                }
            };
        }
    }
}
