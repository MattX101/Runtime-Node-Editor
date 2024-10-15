using RNE.Template.Node;
using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class IntInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Int");
            IntInputNode node = root.AddComponent<IntInputNode>();

            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Default, "Int");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.Int), 0).AddComponent<IntOutputPointer>(), (int)ValueType.Int);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.outputs[0].gameObject.transform, TMP_InputField.ContentType.IntegerNumber)
                }
            };
        }
    }
}
