using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node.Elements;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class CharOutputUI : NodeUI
    {
        public CharOutputUI() : base("CharOutputUI")
        {
            CreateRoot("Char");
            CharOutputNode charOutputNode = root.AddComponent<CharOutputNode>();
            charOutputNode.endNode = true;
            charOutputNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(charOutputNode, Color.gray, "Char");

            inputs[0] = CreatePointer("In", ValueType.Char, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = charOutputNode;
            inputs[0].valueType = ValueType.Char;

            elements = new NodeUIElements(1, 0, 0);

            elements.inputFields[0] = AddInputField(
                inputs[0].gameObject.transform,
                TMP_InputField.ContentType.Name,
                0,
                true,
                false);

            charOutputNode.AddPointers(inputs, outputs);
        }
    }
}
