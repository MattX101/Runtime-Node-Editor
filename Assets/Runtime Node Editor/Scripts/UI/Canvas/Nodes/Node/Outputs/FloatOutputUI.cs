using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class FloatOutputUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Float");
            FloatOutputNode node = root.AddComponent<FloatOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(node, NodeColor.Default, "Float");

            node.AddPointer(CreatePointer("In", ValueType.Float, 0, true).AddComponent<InputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        true,
                        false)
                }
            };
        }
    }
}
