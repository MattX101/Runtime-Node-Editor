using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class CharOutputUI : NodeUI
    {
        public CharOutputUI()
        {
            CreateRoot("Char");
            CharOutputNode charOutputNode = root.AddComponent<CharOutputNode>();
            charOutputNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            interactablePreview = false;
            toggleInputField = true;
            isInput = false;

            CreateNodeUI(Color.gray, "Char");

            inputs[0] = CreatePointer("In", ValueType.Char, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = charOutputNode;
            inputs[0].valueType = ValueType.Char;

            inputFields = new TMP_InputField[1];
            inputFields[0] = AddInputField(
                inputs[0].gameObject.transform,
                TMP_InputField.ContentType.Name,
                0,
                true,
                false);

            charOutputNode.AddPointers(inputs, outputs);
        }
    }
}
