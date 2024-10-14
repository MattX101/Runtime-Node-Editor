using RNE.Template.Node;
using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;

namespace RNE.Template.UI.Node
{
    public class BoolInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Bool");
            BoolInputNode node = root.AddComponent<BoolInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            
            CreateNodeUI(node, NodeColor.Default, "Bool");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Bool), 0).AddComponent<BoolOutputPointer>(), (int)ValueType.Bool);

            node.Elements = new NodeUIElements(0, 1)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node, node.outputs[0].transform, false, true)
                }
            };
        }
    }
}
