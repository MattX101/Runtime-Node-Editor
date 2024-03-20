using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.Component;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class BoolInputUI : NodeUI
    {
        public BoolInputUI()
        {
            CreateRoot("Bool");
            BoolInputNode boolInputNode = root.AddComponent<BoolInputNode>();
            boolInputNode.nodeUI = this;

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

            buttons = new BooleanButton[1];
            buttons[0] = AddBooleanPreview(outputs[0].transform, false);

            boolInputNode.AddPointers(inputs, outputs);
        }
    }
}
