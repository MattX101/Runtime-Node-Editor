using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
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
