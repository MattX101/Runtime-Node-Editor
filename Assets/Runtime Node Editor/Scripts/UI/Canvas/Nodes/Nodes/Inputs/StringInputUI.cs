using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class StringInputUI : NodeUI
    {
        public StringInputUI()
        {
            CreateRoot("String");
            StringInputNode stringInputNode = root.AddComponent<StringInputNode>();
            stringInputNode.nodeUI = this;

            numOfInputs = 0;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(Color.gray, "String");

            outputs[0] = CreatePointer("Out", ValueType.String, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = stringInputNode;
            outputs[0].valueType = ValueType.String;

            inputFields = new TMP_InputField[1];
            inputFields[0] = AddInputField(
                outputs[0].gameObject.transform,
                TMP_InputField.ContentType.Name,
                0,
                false,
                true);

            stringInputNode.AddPointers(inputs, outputs);
        }
    }
}
