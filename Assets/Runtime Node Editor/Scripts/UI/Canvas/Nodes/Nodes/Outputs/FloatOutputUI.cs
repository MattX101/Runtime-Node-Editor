using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class FloatOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Float");
            FloatOutputNode floatOutputNode = root.AddComponent<FloatOutputNode>();
            floatOutputNode.endNode = true;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(floatOutputNode, Color.gray, "Float");

            inputs[0] = CreatePointer("In", ValueType.Float, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = floatOutputNode;
            inputs[0].valueType = ValueType.Float;

            floatOutputNode.elements = new NodeUIElements(1, 0, 0);

            floatOutputNode.elements.inputFields[0] = AddInputField(
                inputs[0].gameObject.transform,
                TMP_InputField.ContentType.DecimalNumber,
                0,
                true,
                false);

            floatOutputNode.AddPointers(inputs, outputs);
        }
    }
}
