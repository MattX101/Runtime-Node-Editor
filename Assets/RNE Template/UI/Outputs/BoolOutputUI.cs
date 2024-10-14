using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;

namespace RNE.Template.UI.Node
{
    public class BoolOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Bool");
            BoolOutputNode node = root.AddComponent<BoolOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Bool");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.Bool), 0, true).AddComponent<InputPointer>(), (int)ValueType.Bool);

            node.Elements = new NodeUIElements(0, 1)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node, node.inputs[0].transform, true)
                }
            };
        }
    }
}
