using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using TMPro;

namespace RNE.Template.UI.Node
{
    public class FloatOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Float");
            FloatOutputNode node = RootObject.AddComponent<FloatOutputNode>();
            node.Init();

            NumOfInputs = 1;

            CreateNodeUI(node, NodeColor.Default, "Float");

            node.AddPointer(CreatePointer("In", PointerColor.PickColor(ValueType.Float), 0, true).AddComponent<InputPointer>(), (int)ValueType.Float);

            node.Elements = new NodeUIElements(1)
            {
                InputFields =
                {
                    [0] = AddInputField(
                        node,
                        node.Inputs[0].gameObject.transform,
                        TMP_InputField.ContentType.DecimalNumber,
                        true,
                        false)
                }
            };
        }
    }
}
