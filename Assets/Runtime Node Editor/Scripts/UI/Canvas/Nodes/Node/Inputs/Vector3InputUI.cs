using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3InputUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 3");
            Vector3InputNode node = root.AddComponent<Vector3InputNode>();

            NumOfOutputs = 4;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Vector 3");

            node.AddPointer(CreatePointer("Out", ValueType.Vector3, 0).AddComponent<Vector3OutputPointer>(), ValueType.Vector3);

            node.AddPointer(CreatePointer("X", ValueType.Float, 1).AddComponent<FloatOutputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Y", ValueType.Float, 2).AddComponent<FloatOutputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Z", ValueType.Float, 3).AddComponent<FloatOutputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(3)
            {
                InputFields =
                {
                    [0] = AddInputField(node.outputs[1].gameObject.transform, TMP_InputField.ContentType.DecimalNumber),
                    [1] = AddInputField(node.outputs[2].gameObject.transform, TMP_InputField.ContentType.DecimalNumber),
                    [2] = AddInputField(node.outputs[3].gameObject.transform, TMP_InputField.ContentType.DecimalNumber)
                }
            };
        }
    }
}
