using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Functions.UI.Elements;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class BoolOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Bool");
            BoolOutputNode boolOutputNode = root.AddComponent<BoolOutputNode>();
            boolOutputNode.endNode = true;

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

            boolOutputNode.elements = new NodeUIElements(0, 1, 0);

            boolOutputNode.elements.buttons[0] = AddBooleanPreview(inputs[0].transform, true);

            boolOutputNode.AddPointers(inputs, outputs);
        }
    }
}
