using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringContainsWordUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Contains Word");
            StringContainsWordNode node = root.AddComponent<StringContainsWordNode>();

            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Contains Word");

            node.AddPointer(CreatePointer("In", ValueType.String, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);
            node.AddPointer(CreatePointer("In", ValueType.String, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.String);
            
            node.AddPointer(CreatePointer("Out", ValueType.Bool, 0).AddComponent<BoolOutputPointer>(), ValueType.Bool);

            node.Elements = new NodeUIElements(2, 1)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false),
                    [1] = AddHalfInputField(
                        node.inputs[1].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false)
                },
                Buttons =
                {
                    [0] = AddBooleanPreview(node.outputs[0].transform),
                },
            };
        }
    }
}