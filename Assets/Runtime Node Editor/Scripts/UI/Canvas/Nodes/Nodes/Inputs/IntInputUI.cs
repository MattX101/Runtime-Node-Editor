using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class IntInputUI : NodeUI
    {
        public IntInputUI()
        {
            CreateRoot("Int");
            IntInputNode intInputNode = root.AddComponent<IntInputNode>();
            intInputNode.nodeUI = this;

            numOfInputs = 0;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(intInputNode, Color.gray, "Int");

            outputs[0] = CreatePointer("Out", ValueType.Int, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = intInputNode;
            outputs[0].valueType = ValueType.Int;

            inputFields = new TMP_InputField[1];
            inputFields[0] = AddInputField(
                outputs[0].gameObject.transform,
                TMP_InputField.ContentType.IntegerNumber,
                0,
                false,
                true);

            intInputNode.AddPointers(inputs, outputs);
        }
    }
}
