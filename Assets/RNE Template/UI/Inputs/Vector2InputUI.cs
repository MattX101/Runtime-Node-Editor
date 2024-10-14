using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public class Vector2InputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 2");
            Vector2InputNode node = root.AddComponent<Vector2InputNode>();

            NumOfOutputs = 3;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Vector 2");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Vector2), 0).AddComponent<Vector2OutputPointer>(), (int)ValueType.Vector2);

            node.AddPointer(CreatePointer("X", PointerColor.PickColor(ValueType.Float), 1).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Y", PointerColor.PickColor(ValueType.Float), 2).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);

            node.Elements = new NodeUIElements(2)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.outputs[1].gameObject.transform, TMP_InputField.ContentType.DecimalNumber),
                    [1] = AddInputField(node, node.outputs[2].gameObject.transform, TMP_InputField.ContentType.DecimalNumber)
                }
            };
        }
    }
}
