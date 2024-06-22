using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3InputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector 3");
            Vector3InputNode vector3InputNode = root.AddComponent<Vector3InputNode>();

            NumOfInputs = 0;
            outputs = new OutputPointer[4];
            NumOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(vector3InputNode, Color.gray, "Vector 3");

            outputs[0] = CreatePointer("Out", ValueType.Vector3, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = vector3InputNode;
            outputs[0].valueType = ValueType.Vector3;

            outputs[1] = CreatePointer("X", ValueType.Float, 1, false, false).AddComponent<OutputPointer>();
            outputs[1].name = "X";
            outputs[1].node = vector3InputNode;
            outputs[1].valueType = ValueType.Float;
            outputs[2] = CreatePointer("Y", ValueType.Float, 2, false, false).AddComponent<OutputPointer>();
            outputs[2].name = "Y";
            outputs[2].node = vector3InputNode;
            outputs[2].valueType = ValueType.Float;
            outputs[3] = CreatePointer("Z", ValueType.Float, 3, false, false).AddComponent<OutputPointer>();
            outputs[3].name = "Z";
            outputs[3].node = vector3InputNode;
            outputs[3].valueType = ValueType.Float;

            vector3InputNode.Elements = new NodeUIElements(3, 0, 0)
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
                        true),
                    [2] = AddInputField(
                        outputs[3].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        false,
                        true)
                }
            };

            vector3InputNode.AddPointers(inputs, outputs);
        }
    }
}
