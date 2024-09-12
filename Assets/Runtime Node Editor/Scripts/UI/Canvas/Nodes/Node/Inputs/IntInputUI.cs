using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class IntInputUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Int");
            IntInputNode node = root.AddComponent<IntInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Int");

            node.AddPointer(CreatePointer("Out", ValueType.Int, 0).AddComponent<IntOutputPointer>(), ValueType.Int);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(node.outputs[0].gameObject.transform, TMP_InputField.ContentType.IntegerNumber)
                }
            };
        }
    }
}
