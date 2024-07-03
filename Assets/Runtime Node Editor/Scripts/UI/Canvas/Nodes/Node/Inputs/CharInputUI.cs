using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.UI.Elements;
using RuntimeNodeEditor.Functions.UI.Elements;
using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Char");
            CharInputNode node = root.AddComponent<CharInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(node, Color.gray, "Char");

            node.AddPointer(CreatePointer("Out", ValueType.Char, 0).AddComponent<OutputPointer>(), ValueType.Char);

            node.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(node.outputs[0].gameObject.transform, TMP_InputField.ContentType.Name)
                }
            };

            UIInputField.SetSingleCharacterInputField(node.Elements.InputFields[0]);
        }
    }
}
