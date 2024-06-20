using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3OutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector 3");
            Vector3OutputNode vector3OutputNode = root.AddComponent<Vector3OutputNode>();
            vector3OutputNode.endNode = true;

            inputs = new InputPointer[4];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(vector3OutputNode, Color.gray, "Vector 3");

            inputs[0] = CreatePointer("In", ValueType.Vector3, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = vector3OutputNode;
            inputs[0].valueType = ValueType.Vector3;

            inputs[1] = CreatePointer("X", ValueType.Float, 1, false, true).AddComponent<InputPointer>();
            inputs[1].name = "X";
            inputs[1].node = vector3OutputNode;
            inputs[1].valueType = ValueType.Float;
            inputs[2] = CreatePointer("Y", ValueType.Float, 2, false, true).AddComponent<InputPointer>();
            inputs[2].name = "Y";
            inputs[2].node = vector3OutputNode;
            inputs[2].valueType = ValueType.Float;
            inputs[3] = CreatePointer("Z", ValueType.Float, 3, false, true).AddComponent<InputPointer>();
            inputs[3].name = "Z";
            inputs[3].node = vector3OutputNode;
            inputs[3].valueType = ValueType.Float;

            vector3OutputNode.elements = new NodeUIElements(3, 0, 0)
            {
                inputFields =
                {
                    [0] = AddInputField(
                        inputs[1].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        true,
                        false),
                    [1] = AddInputField(
                        inputs[2].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        true,
                        false),
                    [2] = AddInputField(
                        inputs[3].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        true,
                        false)
                }
            };

            vector3OutputNode.AddPointers(inputs, outputs);
        }
    }
}
