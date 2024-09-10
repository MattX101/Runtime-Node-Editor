using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("String");
            StringOutputNode node = root.AddComponent<StringOutputNode>();
            node.endNode = true;
            
            NumOfInputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "String");

            node.AddPointer(CreatePointer("In", ValueType.String, 0, true).AddComponent<InputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false)
                }
            };
        }
    }
}
