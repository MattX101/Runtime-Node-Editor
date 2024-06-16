using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    internal class Vector2OutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector 2");
            Vector2OutputNode vector2OutputNode = root.AddComponent<Vector2OutputNode>();
            vector2OutputNode.endNode = true;

            inputs = new InputPointer[3];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(vector2OutputNode, Color.gray, "Vector 2");

            inputs[0] = CreatePointer("In", ValueType.Vector2, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = vector2OutputNode;
            inputs[0].valueType = ValueType.Vector2;

            inputs[1] = CreatePointer("X", ValueType.Float, 1, false, true).AddComponent<InputPointer>();
            inputs[1].name = "X";
            inputs[1].node = vector2OutputNode;
            inputs[1].valueType = ValueType.Float;
            inputs[2] = CreatePointer("Y", ValueType.Float, 2, false, true).AddComponent<InputPointer>();
            inputs[2].name = "Y";
            inputs[2].node = vector2OutputNode;
            inputs[2].valueType = ValueType.Float;

            vector2OutputNode.elements = new NodeUIElements(2, 0, 0);

            vector2OutputNode.elements.inputFields[0] = AddInputField(
                inputs[1].gameObject.transform,
                TMP_InputField.ContentType.DecimalNumber,
                0,
                true,
                false);
            vector2OutputNode.elements.inputFields[1] = AddInputField(
                inputs[2].gameObject.transform,
                TMP_InputField.ContentType.DecimalNumber,
                0,
                true,
                false);

            vector2OutputNode.AddPointers(inputs, outputs);
        }
    }
}
