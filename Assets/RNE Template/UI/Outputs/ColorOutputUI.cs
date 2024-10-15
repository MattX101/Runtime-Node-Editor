using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Canvas.Node;

namespace RNE.Template.UI.Node
{
    public class ColorOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(nodeId);

            PopulateRoot("Color");
            ColorOutputNode node = root.AddComponent<ColorOutputNode>();
            node.endNode = true;

            NumOfInputs = 1;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(node, NodeColor.Default, "Color");
            node.ImagePreview = ImagePreview;

            node.AddPointer(CreatePointer("Color", PointerColor.PickColor(ValueType.Color), 0, true).AddComponent<InputPointer>(), (int)ValueType.Color);
        }
    }
}
