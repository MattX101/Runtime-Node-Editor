using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    internal class StringInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("String");
            StringInputNode stringInputNode = root.AddComponent<StringInputNode>();

            numOfInputs = 0;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(stringInputNode, Color.gray, "String");

            outputs[0] = CreatePointer("Out", ValueType.String, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = stringInputNode;
            outputs[0].valueType = ValueType.String;

            stringInputNode.elements = new NodeUIElements(1, 0, 0);

            stringInputNode.elements.inputFields[0] = AddInputField(
                outputs[0].gameObject.transform,
                TMP_InputField.ContentType.Name,
                0,
                false,
                true);

            stringInputNode.AddPointers(inputs, outputs);
        }
    }
}
