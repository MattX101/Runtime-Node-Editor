using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
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
