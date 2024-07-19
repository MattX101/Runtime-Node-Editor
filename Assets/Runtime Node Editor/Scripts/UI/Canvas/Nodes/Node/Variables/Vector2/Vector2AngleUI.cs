using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector2AngleUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Angle");
			Vector2AngleNode node = root.AddComponent<Vector2AngleNode>();

            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Angle");

            node.AddPointer(CreatePointer("In A", ValueType.Vector2, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Vector2);
            node.AddPointer(CreatePointer("In B", ValueType.Vector2, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Vector2);
            
            node.AddPointer(CreatePointer("Out", ValueType.Float, 0).AddComponent<FloatOutputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        false,
                        false,
                        true)
                }
            };
        }
    }
}