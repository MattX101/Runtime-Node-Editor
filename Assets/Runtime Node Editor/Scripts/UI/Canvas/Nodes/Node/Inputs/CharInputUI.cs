using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.UI.Elements;
using RuntimeNodeEditor.Functions.UI.Elements;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class CharInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Char");
            CharInputNode node = root.AddComponent<CharInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;
            toggleInputField = true;
            isInput = true;

            CreateNodeUI(node, NodeColor.Default, "Char");

            node.AddPointer(CreatePointer("Out", ValueType.Char, 0).AddComponent<CharOutputPointer>(), ValueType.Char);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(node.outputs[0].gameObject.transform, TMP_InputField.ContentType.Standard)
                }
            };

            UIInputField.SetSingleCharacterInputField(node.Elements.InputFields[0]);
        }
    }
}
