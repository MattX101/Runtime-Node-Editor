using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class Vector2InputUI : NodeUI
    {
        public Vector2InputUI()
        {
            CreateRoot("Vector 2");
            Vector2InputNode vector2InputNode = root.AddComponent<Vector2InputNode>();
            vector2InputNode.nodeUI = this;

            numOfInputs = 0;
            outputs = new OutputPointer[3];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(Color.gray, "Vector 2");

            outputs[0] = CreatePointer("Out", ValueType.Vector2, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = vector2InputNode;
            outputs[0].valueType = ValueType.Vector2;

            outputs[1] = CreatePointer("X", ValueType.Float, 1, false, false).AddComponent<OutputPointer>();
            outputs[1].name = "X";
            outputs[1].node = vector2InputNode;
            outputs[1].valueType = ValueType.Float;
            outputs[2] = CreatePointer("Y", ValueType.Float, 2, false, false).AddComponent<OutputPointer>();
            outputs[2].name = "Y";
            outputs[2].node = vector2InputNode;
            outputs[2].valueType = ValueType.Float;

            inputFields = new TMP_InputField[2];
            inputFields[0] = AddInputField(
                outputs[1].gameObject.transform,
                TMP_InputField.ContentType.DecimalNumber,
                0,
                false,
                true);
            inputFields[1] = AddInputField(
                outputs[2].gameObject.transform,
                TMP_InputField.ContentType.DecimalNumber,
                0,
                false,
                true);

            vector2InputNode.AddPointers(inputs, outputs);
        }
    }
}
