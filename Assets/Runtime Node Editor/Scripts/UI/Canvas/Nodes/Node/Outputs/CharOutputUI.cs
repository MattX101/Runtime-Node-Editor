using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Char");
            CharOutputNode node = root.AddComponent<CharOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(node, NodeColor.Default, "Char");

            node.AddPointer(CreatePointer("In", ValueType.Char, 0, true).AddComponent<InputPointer>(), ValueType.Char);

            node.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false)
                }
            };
        }
    }
}
