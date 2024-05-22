using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node.Elements;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class StringOutputUI : NodeUI
    {
        public StringOutputUI() : base("StringOutputUI")
        {
            CreateRoot("String");
            StringOutputNode stringOutputNode = root.AddComponent<StringOutputNode>();
            stringOutputNode.endNode = true;
            stringOutputNode.nodeUI = this;
            
            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(stringOutputNode, Color.gray, "String");

            inputs[0] = CreatePointer("In", ValueType.String, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = stringOutputNode;
            inputs[0].valueType = ValueType.String;

            elements = new NodeUIElements(1, 0, 0);

            elements.inputFields[0] = AddInputField(
                inputs[0].gameObject.transform,
                TMP_InputField.ContentType.IntegerNumber,
                0,
                true,
                false);

            stringOutputNode.AddPointers(inputs, outputs);
        }
    }
}
