using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector2MagnitudeUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Magnitude");
            Vector2MagnitudeNode node = root.AddComponent<Vector2MagnitudeNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Magnitude");

            node.AddPointer(CreatePointer("In", ValueType.Vector2, 0, true).AddComponent<InputPointer>(), ValueType.Vector2);
            node.AddPointer(CreatePointer("Out", ValueType.Float, 0).AddComponent<OutputPointer>(), ValueType.Float);

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