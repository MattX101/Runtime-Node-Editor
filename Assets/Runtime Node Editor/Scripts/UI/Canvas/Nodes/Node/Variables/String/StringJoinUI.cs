using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringJoinUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Join");
            StringJoinNode node = root.AddComponent<StringJoinNode>();

            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Join");

            node.AddPointer(CreateArrayPointer("Values", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String, RuntimeNodeEditor.Nodes.Pointer.Type.PointerType.Array);
            node.AddPointer(CreatePointer("Seperator", ValueType.Char, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char);

            node.AddPointer(CreatePointer("Out", ValueType.String, 0).AddComponent<StringOutputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(2)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        false,
                        false,
                        true),
                    [1] = AddHalfInputField(
                        node.inputs[1].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false),
                }
            };
        }
    }
}
