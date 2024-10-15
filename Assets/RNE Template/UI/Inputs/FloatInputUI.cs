using RNE.Template.Node;
using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using TMPro;

namespace RNE.Template.UI.Node
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
