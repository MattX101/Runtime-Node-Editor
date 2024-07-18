using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class ColorLerpUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Color Lerp");
            ColorLerpNode node = root.AddComponent<ColorLerpNode>();

            NumOfInputs = 3;
            NumOfOutputs = 1;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(node, NodeColor.Default, "Color Lerp");
            node.ImagePreview = ImagePreview;

            node.AddPointer(CreatePointer("Color 1", ValueType.Color, 0, true).AddComponent<InputPointer>(), ValueType.Color);
            node.AddPointer(CreatePointer("Color 2", ValueType.Color, 1, true).AddComponent<InputPointer>(), ValueType.Color);
            node.AddPointer(CreatePointer("Time", ValueType.Float, 2, true).AddComponent<InputPointer>(), ValueType.Float);

            node.AddPointer(CreatePointer("Out", ValueType.Color, 0).AddComponent<OutputPointer>(), ValueType.Color);
        }
    }
}