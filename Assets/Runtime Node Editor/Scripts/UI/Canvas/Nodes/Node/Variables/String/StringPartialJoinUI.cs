using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringPartialJoinUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Partial Join");
            StringPartialJoinNode node = root.AddComponent<StringPartialJoinNode>();

            NumOfInputs = 4;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Partial Join");

            node.AddPointer(CreateArrayPointer("Values", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String, RuntimeNodeEditor.Nodes.Pointer.Type.PointerType.Array);
            node.AddPointer(CreatePointer("Seperator", ValueType.Char, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char);
            node.AddPointer(CreatePointer("Start Index", ValueType.Int, 2, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Int);
            node.AddPointer(CreatePointer("Count", ValueType.Int, 3, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Int);

            node.AddPointer(CreatePointer("Out", ValueType.String, 0).AddComponent<StringOutputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(4)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(
                        node.inputs[1].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false),
                    [1] = AddHalfInputField(
                        node.inputs[2].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false),
                    [2] = AddHalfInputField(
                        node.inputs[3].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false),
                    [3] = AddInputField(
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