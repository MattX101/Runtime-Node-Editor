using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector2InputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector 2");
            Vector2InputNode node = root.AddComponent<Vector2InputNode>();

            NumOfOutputs = 3;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Vector 2");

            node.AddPointer(CreatePointer("Out", ValueType.Vector2, 0).AddComponent<Vector2OutputPointer>(), ValueType.Vector2);

            node.AddPointer(CreatePointer("X", ValueType.Float, 1).AddComponent<FloatOutputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Y", ValueType.Float, 2).AddComponent<FloatOutputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(2, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(node.outputs[1].gameObject.transform, TMP_InputField.ContentType.DecimalNumber),
                    [1] = AddInputField(node.outputs[2].gameObject.transform, TMP_InputField.ContentType.DecimalNumber)
                }
            };
        }
    }
}
