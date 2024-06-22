using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class BoolOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Bool");
            BoolOutputNode boolOutputNode = root.AddComponent<BoolOutputNode>();
            boolOutputNode.endNode = true;

            inputs = new InputPointer[1];
            NumOfInputs = inputs.Length;
            NumOfOutputs = 0;

            drawBodyImage = false;
            interactablePreview = true;

            CreateNodeUI(boolOutputNode, Color.gray, "Bool");

            inputs[0] = CreatePointer("In", ValueType.Bool, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = boolOutputNode;
            inputs[0].valueType = ValueType.Bool;

            boolOutputNode.Elements = new NodeUIElements(0, 1, 0)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(inputs[0].transform, true)
                }
            };

            boolOutputNode.AddPointers(inputs, outputs);
        }
    }
}
