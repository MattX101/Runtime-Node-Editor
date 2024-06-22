using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector2InputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector 2");
            Vector2InputNode vector2InputNode = root.AddComponent<Vector2InputNode>();

            NumOfInputs = 0;
            outputs = new OutputPointer[3];
            NumOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(vector2InputNode, Color.gray, "Vector 2");

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

            vector2InputNode.Elements = new NodeUIElements(2, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        outputs[1].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        false,
                        true),
                    [1] = AddInputField(
                        outputs[2].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        false,
                        true)
                }
            };

            vector2InputNode.AddPointers(inputs, outputs);
        }
    }
}
