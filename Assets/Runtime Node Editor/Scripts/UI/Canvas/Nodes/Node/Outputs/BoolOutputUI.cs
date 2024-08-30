using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class BoolOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Bool");
            BoolOutputNode node = root.AddComponent<BoolOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;
            interactablePreview = true;

            CreateNodeUI(node, NodeColor.Default, "Bool");

            node.AddPointer(CreatePointer("In", ValueType.Bool, 0, true).AddComponent<SingleConnectionInputPointer>(), ValueType.Bool);

            node.Elements = new NodeUIElements(0, 1)
            {
                Buttons =
                {
                    [0] = AddBooleanPreview(node.inputs[0].transform, true)
                }
            };
        }
    }
}
