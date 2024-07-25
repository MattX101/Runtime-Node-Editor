using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringIndexOfUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Index Of");
            StringIndexOfNode node = root.AddComponent<StringIndexOfNode>();

            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Index Of");

            node.AddPointer(CreatePointer("Value", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);
            node.AddPointer(CreatePointer("Character", ValueType.Char, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Char);

            node.AddPointer(CreatePointer("Out", ValueType.Int, 0).AddComponent<IntOutputPointer>(), ValueType.Int);

            node.Elements = new NodeUIElements(3)
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
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        false,
                        false,
                        true),
                },
            };
        }
    }
}