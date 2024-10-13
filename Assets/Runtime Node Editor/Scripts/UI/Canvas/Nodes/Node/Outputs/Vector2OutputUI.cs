using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector2OutputUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 2");
            Vector2OutputNode node = root.AddComponent<Vector2OutputNode>();
            node.endNode = true;

            NumOfInputs = 3;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Vector 2");

            node.AddPointer(CreatePointer("In", ValueType.Vector2, 0, true).AddComponent<InputPointer>(), ValueType.Vector2);

            node.AddPointer(CreatePointer("X", ValueType.Float, 1, true).AddComponent<InputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Y", ValueType.Float, 2, true).AddComponent<InputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(2)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node,
                        node.inputs[1].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        true,
                        false),
                    [1] = AddInputField(
                        node,
                        node.inputs[2].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        true,
                        false)
                }
            };
        }
    }
}
