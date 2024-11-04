using RNE.Template.Node;
using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class StringInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("String");
            StringInputNode node = RootObject.AddComponent<StringInputNode>();

            NumOfOutputs = 1;

            CreateNodeUI(node, NodeColor.Default, "String");

            node.AddPointer(CreatePointer("Out", PointerColor.PickColor(ValueType.String), 0).AddComponent<StringOutputPointer>(), (int)ValueType.String);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(node, node.Outputs[0].gameObject.transform, TMP_InputField.ContentType.Standard)
                }
            };
        }
    }
}
