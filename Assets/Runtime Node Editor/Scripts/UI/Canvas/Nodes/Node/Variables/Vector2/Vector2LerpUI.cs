using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector2LerpUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Lerp");
            Vector2LerpNode node = root.AddComponent<Vector2LerpNode>();

            NumOfInputs = 3;
            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Lerp");

            node.AddPointer(CreatePointer("In A", ValueType.Vector2, 0, true).AddComponent<InputPointer>(), ValueType.Vector2);
            node.AddPointer(CreatePointer("In B", ValueType.Vector2, 1, true).AddComponent<InputPointer>(), ValueType.Vector2);
            node.AddPointer(CreatePointer("Time", ValueType.Float, 2, true).AddComponent<InputPointer>(), ValueType.Float);
            
            node.AddPointer(CreatePointer("Out", ValueType.Vector2, 0).AddComponent<OutputPointer>(), ValueType.Vector2);

            node.Elements = new NodeUIElements(2, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        false,
                        false,
                        true),
                    [1] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        false,
                        false,
                        true,
                        1)
                }
            };
        }
    }
}