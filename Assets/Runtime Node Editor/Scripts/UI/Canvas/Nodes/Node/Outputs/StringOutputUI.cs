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
            base.Init(nodeId);

            PopulateRoot("String");
            StringOutputNode node = root.AddComponent<StringOutputNode>();
            node.endNode = true;
            
            NumOfInputs = 1;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(node, NodeColor.Default, "String");

            node.AddPointer(CreatePointer("In", ValueType.String, 0, true).AddComponent<InputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(1, 0, 0)
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
