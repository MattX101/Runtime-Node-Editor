using RuntimeNodeEditor.Node.UIFunctions.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RNE.Template.Node;
using RNE.Template.Node.Pointer.Data;
using RNE.Template.Node.Pointer.Value;
using RNE.Template.Node.Pointer;
using Utils.StringParameterExtractor;
using UnityEngine;

namespace RNE.Template.UI.Node
{
    public class ColorInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            InitBase(StringParameterExtractor.ExtractBase(nodeId));

            PopulateRoot("Color");
            ColorInputNode node = root.AddComponent<ColorInputNode>();

            NumOfOutputs = 4;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(node, NodeColor.Default, "Color");

            node.AddPointer(CreatePointer("Color", PointerColor.PickColor(ValueType.Color), 0).AddComponent<ColorOutputPointer>(), (int)ValueType.Color);

            node.AddPointer(CreatePointer("Red", PointerColor.PickColor(ValueType.Float), 1).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Green", PointerColor.PickColor(ValueType.Float), 2).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);
            node.AddPointer(CreatePointer("Blue", PointerColor.PickColor(ValueType.Float), 3).AddComponent<FloatOutputPointer>(), (int)ValueType.Float);

            node.Elements = new NodeUIElements(0, 0, 3)
            {
                Sliders =
                {
                    [0] = AddIntegerSlider(node.outputs[1].transform, Color.red, 255),
                    [1] = AddIntegerSlider(node.outputs[2].transform, Color.green, 255),
                    [2] = AddIntegerSlider(node.outputs[3].transform, Color.blue, 255)
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
