using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class FloatInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Float");
            FloatInputNode floatInputNode = root.AddComponent<FloatInputNode>();

            numOfInputs = 0;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(floatInputNode, Color.gray, "Float");

            outputs[0] = CreatePointer("Out", ValueType.Float, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = floatInputNode;
            outputs[0].valueType = ValueType.Float;

            floatInputNode.elements = new NodeUIElements(1, 0, 0);

            floatInputNode.elements.inputFields[0] = AddInputField(
                outputs[0].gameObject.transform,
                TMP_InputField.ContentType.DecimalNumber,
                0,
                false,
                true);

            floatInputNode.AddPointers(inputs, outputs);
        }
    }
}
