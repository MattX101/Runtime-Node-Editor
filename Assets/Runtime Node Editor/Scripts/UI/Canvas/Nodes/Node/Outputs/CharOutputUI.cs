using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Char");
            CharOutputNode charOutputNode = root.AddComponent<CharOutputNode>();
            charOutputNode.endNode = true;

            inputs = new InputPointer[1];
            NumOfInputs = inputs.Length;
            NumOfOutputs = 0;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(charOutputNode, Color.gray, "Char");

            inputs[0] = CreatePointer("In", ValueType.Char, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = charOutputNode;
            inputs[0].valueType = ValueType.Char;

            charOutputNode.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Name,
                        0,
                        true,
                        false)
                }
            };

            charOutputNode.AddPointers(inputs, outputs);
        }
    }
}
