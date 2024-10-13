using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3OutputUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 3");
            Vector3OutputNode node = root.AddComponent<Vector3OutputNode>();
            node.endNode = true;

            NumOfInputs = 4;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Vector 3");

            node.AddPointer(CreatePointer("In", ValueType.Vector3, 0, true).AddComponent<InputPointer>(), ValueType.Vector3);

            node.AddPointer(CreatePointer("X", ValueType.Float, 1, true).AddComponent<InputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Y", ValueType.Float, 2, true).AddComponent<InputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Z", ValueType.Float, 3, true).AddComponent<InputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(3)
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
                        false),
                    [2] = AddInputField(
                        node,
                        node.inputs[3].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        true,
                        false)
                }
            };
        }
    }
}
