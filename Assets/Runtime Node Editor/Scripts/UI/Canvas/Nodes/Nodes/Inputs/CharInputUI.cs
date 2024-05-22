using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Elements;
using RuntimeNodeEditor.UI.Node.Elements;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class CharInputUI : NodeUI
    {
        public CharInputUI() : base("CharInputUI")
        {
            CreateRoot("Char");
            CharInputNode charInputNode = root.AddComponent<CharInputNode>();
            charInputNode.nodeUI = this;

            numOfInputs = 0;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(charInputNode, Color.gray, "Char");

            outputs[0] = CreatePointer("Out", ValueType.Char, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = charInputNode;
            outputs[0].valueType = ValueType.Char;

            elements = new NodeUIElements(1, 0, 0);

            elements.inputFields[0] = AddInputField(
                outputs[0].gameObject.transform,
                TMP_InputField.ContentType.Name,
                0,
                false,
                true);
            
            UIInputField.SetSingleCharacterInputField(elements.inputFields[0]);

            charInputNode.AddPointers(inputs, outputs);
        }
    }
}
