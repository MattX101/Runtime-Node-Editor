using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class BoolOutputUI : NodeUI
    {
        public BoolOutputUI()
        {
            CreateRoot("Bool");
            BoolOutputNode boolOutputNode = root.AddComponent<BoolOutputNode>();
            boolOutputNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            interactablePreview = true;
            isInput = false;

            CreateNodeUI(Color.gray, "Bool");

            inputs[0] = CreatePointer("In", ValueType.Bool, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = boolOutputNode;
            inputs[0].valueType = ValueType.Bool;

            buttons = new UnityEngine.UI.Button[1];
            buttons[0] = AddBooleanPreview(inputs[0].transform, true);

            boolOutputNode.AddPointers(inputs, outputs);
        }
    }
}
