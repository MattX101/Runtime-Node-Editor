using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class FloatInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Float");
            FloatInputNode node = root.AddComponent<FloatInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Float");

            node.AddPointer(CreatePointer("Out", ValueType.Float, 0).AddComponent<FloatOutputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(node.outputs[0].gameObject.transform, TMP_InputField.ContentType.DecimalNumber)
                }
            };
        }
    }
}
