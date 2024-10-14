using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public class CharInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Char");
            CharInputNode node = root.AddComponent<CharInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Char");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Char), 0).AddComponent<CharOutputPointer>(), (int)ValueType.Char);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(node, node.outputs[0].gameObject.transform, TMP_InputField.ContentType.Standard)
                }
            };

            UIInputField.SetSingleCharacterInputField(node.Elements.InputFields[0]);
        }
    }
}
