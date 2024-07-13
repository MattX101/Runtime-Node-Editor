using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3DistanceUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Distance");
            Vector3DistanceNode node = root.AddComponent<Vector3DistanceNode>();

            NumOfInputs = 2;
            NumOfOutputs = 1;

            drawBodyImage = false;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Distance");

            node.AddPointer(CreatePointer("In A", ValueType.Vector3, 0, true).AddComponent<InputPointer>(), ValueType.Vector3);
            node.AddPointer(CreatePointer("In B", ValueType.Vector3, 1, true).AddComponent<InputPointer>(), ValueType.Vector3);

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