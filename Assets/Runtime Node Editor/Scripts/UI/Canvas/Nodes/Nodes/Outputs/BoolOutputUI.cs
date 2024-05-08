using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.Component;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class BoolOutputUI : NodeUI
    {
        public BoolOutputUI()
        {
            CreateRoot("Bool");
            BoolOutputNode boolOutputNode = root.AddComponent<BoolOutputNode>();
            boolOutputNode.endNode = true;
            boolOutputNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            interactablePreview = true;

            CreateNodeUI(boolOutputNode, Color.gray, "Bool");

            inputs[0] = CreatePointer("In", ValueType.Bool, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = boolOutputNode;
            inputs[0].valueType = ValueType.Bool;

            buttons = new BooleanButton[1];
            buttons[0] = AddBooleanPreview(inputs[0].transform, true);

            boolOutputNode.AddPointers(inputs, outputs);
        }
    }
}
