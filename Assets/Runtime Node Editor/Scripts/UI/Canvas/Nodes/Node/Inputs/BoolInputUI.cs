using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    internal class BoolInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Bool");
            BoolInputNode boolInputNode = root.AddComponent<BoolInputNode>();

            numOfInputs = 0;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            interactablePreview = true;
            isInput = true;
            
            CreateNodeUI(boolInputNode, Color.gray, "Bool");

            outputs[0] = CreatePointer("Out", ValueType.Bool, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = boolInputNode;
            outputs[0].valueType = ValueType.Bool;

            boolInputNode.elements = new NodeUIElements(0, 1, 0);

            boolInputNode.elements.buttons[0] = AddBooleanPreview(outputs[0].transform, false);

            boolInputNode.AddPointers(inputs, outputs);
        }
    }
}
