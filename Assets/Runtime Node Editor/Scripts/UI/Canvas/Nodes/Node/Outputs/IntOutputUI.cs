using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class IntOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Int");
            IntOutputNode node = root.AddComponent<IntOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(node, NodeColor.Default, "Int");

            node.AddPointer(CreatePointer("In", ValueType.Int, 0, true).AddComponent<InputPointer>(), ValueType.Int);

            node.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.IntegerNumber,
                        true,
                        false)
                }
            };
        }
    }
}
