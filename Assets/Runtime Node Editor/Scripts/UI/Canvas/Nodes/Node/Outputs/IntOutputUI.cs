using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class IntOutputUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Int");
            IntOutputNode node = root.AddComponent<IntOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Int");

            node.AddPointer(CreatePointer("In", ValueType.Int, 0, true).AddComponent<InputPointer>(), ValueType.Int);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node,
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.IntegerNumber,
                        true,
                        false)
                }
            };
        }
    }
}
