using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class BoolInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Bool");
            BoolInputNode boolInputNode = root.AddComponent<BoolInputNode>();

            NumOfInputs = 0;
            outputs = new OutputPointer[1];
            NumOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            isInput = true;
            
            CreateNodeUI(boolInputNode, Color.gray, "Bool");

            outputs[0] = CreatePointer("Out", ValueType.Bool, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = boolInputNode;
            outputs[0].valueType = ValueType.Bool;

            boolInputNode.Elements = new NodeUIElements(0, 1, 0)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(outputs[0].transform, false)
                }
            };

            boolInputNode.AddPointers(inputs, outputs);
        }
    }
}
