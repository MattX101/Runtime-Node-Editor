using RNE.Template.Node;
using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class Vector2InputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 2");
            Vector2InputNode node = RootObject.AddComponent<Vector2InputNode>();

            NumOfOutputs = 3;

            CreateNodeUI(node, NodeColor.Default, "Vector 2");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Vector2), 0).AddComponent<Vector2OutputPointer>(), (int)ValueType.Vector2);

            node.AddPointer(CreatePointer("X", PointerColor.PickColor(ValueType.Float), 1).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Y", PointerColor.PickColor(ValueType.Float), 2).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);

            node.Elements = new NodeUIElements(2)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.Outputs[1].gameObject.transform, TMP_InputField.ContentType.DecimalNumber),
                    [1] = AddInputField(node, node.Outputs[2].gameObject.transform, TMP_InputField.ContentType.DecimalNumber)
                }
            };
        }
    }
}
