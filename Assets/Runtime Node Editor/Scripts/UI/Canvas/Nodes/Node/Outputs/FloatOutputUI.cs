using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class FloatOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Float");
            FloatOutputNode floatOutputNode = root.AddComponent<FloatOutputNode>();
            floatOutputNode.endNode = true;

            inputs = new InputPointer[1];
            NumOfInputs = inputs.Length;
            NumOfOutputs = 0;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(floatOutputNode, Color.gray, "Float");

            inputs[0] = CreatePointer("In", ValueType.Float, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = floatOutputNode;
            inputs[0].valueType = ValueType.Float;

            floatOutputNode.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        true,
                        false)
                }
            };

            floatOutputNode.AddPointers(inputs, outputs);
        }
    }
}
