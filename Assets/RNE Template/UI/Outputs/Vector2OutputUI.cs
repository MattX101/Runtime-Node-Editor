using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class Vector2OutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 2");
            Vector2OutputNode node = root.AddComponent<Vector2OutputNode>();
            node.endNode = true;

            NumOfInputs = 3;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Vector 2");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.Vector2), 0, true).AddComponent<InputPointer>(), (int)ValueType.Vector2);

            node.AddPointer(CreatePointer("X", PointerColor.PickColor(ValueType.Float), 1, true).AddComponent<InputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Y", PointerColor.PickColor(ValueType.Float), 2, true).AddComponent<InputPointer>(), (int)ValueType.Float);

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
