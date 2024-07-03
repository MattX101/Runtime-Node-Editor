using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class BoolInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Bool");
            BoolInputNode node = root.AddComponent<BoolInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            interactablePreview = true;
            isInput = true;
            
            CreateNodeUI(node, NodeColor.Default, "Bool");

            node.AddPointer(CreatePointer("Out", ValueType.Bool, 0).AddComponent<OutputPointer>(), ValueType.Bool);

            node.Elements = new NodeUIElements(0, 1, 0)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node.outputs[0].transform, false, true)
                }
            };
        }
    }
}
