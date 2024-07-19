using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3SlerpUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Slerp");
            Vector3SlerpNode node = root.AddComponent<Vector3SlerpNode>();

            NumOfLayers = 1;
            NumOfInputs = 3;
            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Slerp");

            node.AddPointer(CreatePointer("In A", ValueType.Vector3, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Vector3);
            node.AddPointer(CreatePointer("In B", ValueType.Vector3, 1, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Vector3);
            node.AddPointer(CreatePointer("Time", ValueType.Float, 2, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Float);

            node.AddPointer(CreatePointer("Out", ValueType.Vector3, 0).AddComponent<Vector3OutputPointer>(), ValueType.Vector3);

            node.Elements = new NodeUIElements(3)
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
                        1),
                    [2] = AddInputField(
                        node.outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        false,
                        false,
                        true,
                        2),
                }
            };
        }
    }
}