using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class StringOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("String");
            StringOutputNode node = RootObject.AddComponent<StringOutputNode>();
            node.Init();

            NumOfInputs = 1;

            CreateNodeUI(node, NodeColor.Default, "String");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.String), 0, true).AddComponent<InputPointer>(), (int)ValueType.String);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node,
                        node.Inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.Standard,
                        true,
                        false)
                }
            };
        }
    }
}
