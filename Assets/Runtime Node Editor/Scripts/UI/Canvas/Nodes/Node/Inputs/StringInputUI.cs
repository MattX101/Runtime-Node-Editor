using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("String");
            StringInputNode stringInputNode = root.AddComponent<StringInputNode>();

            NumOfInputs = 0;
            outputs = new OutputPointer[1];
            NumOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(stringInputNode, Color.gray, "String");

            outputs[0] = CreatePointer("Out", ValueType.String, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = stringInputNode;
            outputs[0].valueType = ValueType.String;

            stringInputNode.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Name,
                        0,
                        false,
                        true)
                }
            };

            stringInputNode.AddPointers(inputs, outputs);
        }
    }
}
