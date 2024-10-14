using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class Vector3OutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Vector 3");
            Vector3OutputNode node = root.AddComponent<Vector3OutputNode>();
            node.endNode = true;

            NumOfInputs = 4;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Vector 3");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.Vector3), 0, true).AddComponent<InputPointer>(), (int)ValueType.Vector3);

            node.AddPointer(CreatePointer("X", PointerColor.PickColor(ValueType.Float), 1, true).AddComponent<InputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Y", PointerColor.PickColor(ValueType.Float), 2, true).AddComponent<InputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Z", PointerColor.PickColor(ValueType.Float), 3, true).AddComponent<InputPointer>(), (int)ValueType.Float);

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
