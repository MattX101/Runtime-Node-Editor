using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringRemoveUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Remove");
            StringRemoveNode node = root.AddComponent<StringRemoveNode>();

            NumOfInputs = 3;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Remove");

            node.AddPointer(CreatePointer("Value", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);
            node.AddPointer(CreatePointer("Start Index", ValueType.Int, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Int);
            node.AddPointer(CreatePointer("Count", ValueType.Int, 2, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Int);

            node.AddPointer(CreatePointer("Out", ValueType.String, 0).AddComponent<StringOutputPointer>(), ValueType.String);

            node.Elements = new NodeUIElements(4)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false,
                        true),
                    [1] = AddHalfInputField(
                        node.inputs[1].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false,
                        true),
                    [2] = AddHalfInputField(
                        node.inputs[2].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false,
                        true),
                    [3] = AddHalfInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        false,
                        false,
                        true),
                }
            };
        }
    }
}