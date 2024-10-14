using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class CharOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Char");
            CharOutputNode node = root.AddComponent<CharOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Char");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.Char), 0, true).AddComponent<InputPointer>(), (int)ValueType.Char);
            
            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddHalfInputField(
                        node,
                        node.inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false)
                }
            };
        }
    }
}
