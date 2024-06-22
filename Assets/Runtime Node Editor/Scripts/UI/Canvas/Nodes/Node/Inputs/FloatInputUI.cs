using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class FloatInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Float");
            FloatInputNode floatInputNode = root.AddComponent<FloatInputNode>();

            NumOfInputs = 0;
            outputs = new OutputPointer[1];
            NumOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(floatInputNode, Color.gray, "Float");

            outputs[0] = CreatePointer("Out", ValueType.Float, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = floatInputNode;
            outputs[0].valueType = ValueType.Float;

            floatInputNode.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        outputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        0,
                        false,
                        true)
                }
            };

            floatInputNode.AddPointers(inputs, outputs);
        }
    }
}
