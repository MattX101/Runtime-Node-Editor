using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class IntOutputUI : NodeUI
    {
        public IntOutputUI() : base("IntOutputUI")
        {
            CreateRoot("Int");
            IntOutputNode intOutputNode = root.AddComponent<IntOutputNode>();
            intOutputNode.endNode = true;
            intOutputNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(intOutputNode, Color.gray, "Int");

            inputs[0] = CreatePointer("In", ValueType.Int, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = intOutputNode;
            inputs[0].valueType = ValueType.Int;

            inputFields = new TMP_InputField[1];
            inputFields[0] = AddInputField(
                inputs[0].gameObject.transform,
                TMP_InputField.ContentType.IntegerNumber,
                0,
                true,
                false);

            intOutputNode.AddPointers(inputs, outputs);
        }
    }
}
