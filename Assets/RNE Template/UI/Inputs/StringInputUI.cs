using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public class StringInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("String");
            StringInputNode node = root.AddComponent<StringInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "String");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.String), 0).AddComponent<StringOutputPointer>(), (int)ValueType.String);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.outputs[0].gameObject.transform, TMP_InputField.ContentType.Standard)
                }
            };
        }
    }
}
