using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class IntInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Int");
            IntInputNode node = root.AddComponent<IntInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            interactablePreview = true;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(node, Color.gray, "Int");

            node.AddPointer(CreatePointer("Out", ValueType.Int, 0).AddComponent<OutputPointer>(), ValueType.Int);

            node.Elements = new NodeUIElements(1, 0, 0)
            {
                InputFields =
                {
                    [0] = AddInputField(node.outputs[0].gameObject.transform, TMP_InputField.ContentType.IntegerNumber)
                }
            };
        }
    }
}
