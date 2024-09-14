using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using Utils.StringParameterExtractor;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class ColorInputUI : NodeUI
    {
        internal override void Init(string nodeId)
        {
            InitBase(StringParameterExtractor.ExtractBase(nodeId));

            PopulateRoot("Color");
            ColorInputNode node = root.AddComponent<ColorInputNode>();

            NumOfOutputs = 4;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(node, NodeColor.Default, "Color");

            node.AddPointer(CreatePointer("Color", ValueType.Color, 0).AddComponent<ColorOutputPointer>(), ValueType.Color);

            node.AddPointer(CreatePointer("Red", ValueType.Float, 1).AddComponent<FloatOutputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Green", ValueType.Float, 2).AddComponent<FloatOutputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Blue", ValueType.Float, 3).AddComponent<FloatOutputPointer>(), ValueType.Float);

            node.Elements = new NodeUIElements(0, 0, 3)
            {
                Sliders =
                {
                    [0] = AddSlider(node.outputs[1].transform),
                    [1] = AddSlider(node.outputs[2].transform),
                    [2] = AddSlider(node.outputs[3].transform)
                }
            };

            PreviewColor(node.Elements.Sliders[0], node.Elements.Sliders[1], node.Elements.Sliders[2]);
            
            ImagePreview.UpdateNodeOnValueChange(node.Elements.Sliders[0], node.OnValueChangeReset);
            ImagePreview.UpdateNodeOnValueChange(node.Elements.Sliders[1], node.OnValueChangeReset);
            ImagePreview.UpdateNodeOnValueChange(node.Elements.Sliders[2], node.OnValueChangeReset);

            string[] parameters = StringParameterExtractor.ExtractParameters(nodeId);
            if (parameters != null)
            {
                node.Elements.SetSlider(node.Elements.Sliders[0], StringParameterExtractor.ExtractFloat(parameters[0]));
                node.Elements.SetSlider(node.Elements.Sliders[1], StringParameterExtractor.ExtractFloat(parameters[1]));
                node.Elements.SetSlider(node.Elements.Sliders[2], StringParameterExtractor.ExtractFloat(parameters[2]));
            }
        }
    }
}
