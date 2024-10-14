using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public class IntInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Int");
            IntInputNode node = root.AddComponent<IntInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Int");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Int), 0).AddComponent<IntOutputPointer>(), (int)ValueType.Int);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.outputs[0].gameObject.transform, TMP_InputField.ContentType.IntegerNumber)
                }
            };
        }
    }
}
