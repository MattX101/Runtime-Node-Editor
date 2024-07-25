using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringLengthUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Length");
            StringLengthNode node = root.AddComponent<StringLengthNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Length");

            node.AddPointer(CreatePointer("In", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);

            node.AddPointer(CreatePointer("Out", ValueType.Int, 0).AddComponent<IntOutputPointer>(), ValueType.Int);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        false,
                        false, 
                        true)
                }
            };
        }
    }
}