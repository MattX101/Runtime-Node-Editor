using RNE.Template.Node;
using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class Vector3InputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 3");
            Vector3InputNode node = root.AddComponent<Vector3InputNode>();

            NumOfOutputs = 4;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Vector 3");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Vector3), 0).AddComponent<Vector3OutputPointer>(), (int)ValueType.Vector3);

            node.AddPointer(CreatePointer("X", PointerColor.PickColor(ValueType.Float), 1).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Y", PointerColor.PickColor(ValueType.Float), 2).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Z", PointerColor.PickColor(ValueType.Float), 3).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);

            node.Elements = new NodeUIElements(3)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.outputs[1].gameObject.transform, TMP_InputField.ContentType.DecimalNumber),
                    [1] = AddInputField(node, node.outputs[2].gameObject.transform, TMP_InputField.ContentType.DecimalNumber),
                    [2] = AddInputField(node, node.outputs[3].gameObject.transform, TMP_InputField.ContentType.DecimalNumber)
                }
            };
        }
    }
}
