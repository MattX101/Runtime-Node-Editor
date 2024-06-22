using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("String");
            StringOutputNode stringOutputNode = root.AddComponent<StringOutputNode>();
            stringOutputNode.endNode = true;
            
            inputs = new InputPointer[1];
            NumOfInputs = inputs.Length;
            NumOfOutputs = 0;

            drawBodyImage = false;
            toggleInputField = true;

            CreateNodeUI(stringOutputNode, Color.gray, "String");

            inputs[0] = CreatePointer("In", ValueType.String, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = stringOutputNode;
            inputs[0].valueType = ValueType.String;

            stringOutputNode.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.IntegerNumber,
                        0,
                        true,
                        false)
                }
            };

            stringOutputNode.AddPointers(inputs, outputs);
        }
    }
}
