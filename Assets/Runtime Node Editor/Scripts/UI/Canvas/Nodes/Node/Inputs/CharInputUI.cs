using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.UI.Elements;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Char");
            CharInputNode charInputNode = root.AddComponent<CharInputNode>();

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

            charInputNode.elements = new NodeUIElements(1, 0, 0)
            {
                inputFields =
                {
                    [0] = AddInputField(
                        outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Name,
                        0,
                        false,
                        true)
                }
            };

            UIInputField.SetSingleCharacterInputField(charInputNode.elements.inputFields[0]);

            charInputNode.AddPointers(inputs, outputs);
        }
    }
}
