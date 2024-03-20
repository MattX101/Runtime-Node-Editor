using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class FloatOutputUI : NodeUI
    {
        public FloatOutputUI()
        {
            CreateRoot("Float");
            FloatOutputNode floatOutputNode = root.AddComponent<FloatOutputNode>();
            floatOutputNode.endNode = true;
            floatOutputNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            interactablePreview = false;
            toggleInputField = true;
            isInput = false;

            CreateNodeUI(floatOutputNode, Color.gray, "Float");

            inputs[0] = CreatePointer("In", ValueType.Float, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = floatOutputNode;
            inputs[0].valueType = ValueType.Float;

            inputFields = new TMP_InputField[1];
            inputFields[0] = AddInputField(
                inputs[0].gameObject.transform,
                TMP_InputField.ContentType.DecimalNumber,
                0,
                true,
                false);

            floatOutputNode.AddPointers(inputs, outputs);
        }
    }
}
