using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class ColorInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Color");
            ColorInputNode node = root.AddComponent<ColorInputNode>();

            NumOfOutputs = 4;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(node, Color.gray, "Color");

            node.AddPointer(CreatePointer("Color", ValueType.Color, 0).AddComponent<OutputPointer>(), ValueType.Color);

            node.AddPointer(CreatePointer("Red", ValueType.Float, 1).AddComponent<OutputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Green", ValueType.Float, 2).AddComponent<OutputPointer>(), ValueType.Float);
            node.AddPointer(CreatePointer("Blue", ValueType.Float, 3).AddComponent<OutputPointer>(), ValueType.Float);

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
            
            ImagePreview.UpdateNodeOnValueChange(node.Elements.Sliders[0], node.MoveUp);
            ImagePreview.UpdateNodeOnValueChange(node.Elements.Sliders[1], node.MoveUp);
            ImagePreview.UpdateNodeOnValueChange(node.Elements.Sliders[2], node.MoveUp);
        }
    }
}
