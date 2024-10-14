using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public class FloatInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Float");
            FloatInputNode node = root.AddComponent<FloatInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Float");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Float), 0).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.outputs[0].gameObject.transform, TMP_InputField.ContentType.DecimalNumber)
                }
            };
        }
    }
}
