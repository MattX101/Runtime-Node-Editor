using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public class FloatOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Float");
            FloatOutputNode node = root.AddComponent<FloatOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Float");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.Float), 0, true).AddComponent<InputPointer>(), (int)ValueType.Float);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node,
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        true,
                        false)
                }
            };
        }
    }
}
