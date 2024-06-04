using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class ColorInputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Color");
            ColorInputNode colorInputNode = root.AddComponent<ColorInputNode>();

            numOfInputs = 0;
            outputs = new OutputPointer[4];
            numOfOutputs = outputs.Length;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(colorInputNode, Color.gray, "Color");

            outputs[0] = CreatePointer("Color", ValueType.Color, 0, false, false).AddComponent<OutputPointer>();
            outputs[0].name = "Color";
            outputs[0].node = colorInputNode;
            outputs[0].valueType = ValueType.Color;

            outputs[1] = CreatePointer("Red", ValueType.Float, 1, false, false).AddComponent<OutputPointer>();
            outputs[1].name = "Red";
            outputs[1].node = colorInputNode;
            outputs[1].valueType = ValueType.Float;

            outputs[2] = CreatePointer("Green", ValueType.Float, 2, false, false).AddComponent<OutputPointer>();
            outputs[2].name = "Green";
            outputs[2].node = colorInputNode;
            outputs[2].valueType = ValueType.Float;

            outputs[3] = CreatePointer("Blue", ValueType.Float, 3, false, false).AddComponent<OutputPointer>();
            outputs[3].name = "Blue";
            outputs[3].node = colorInputNode;
            outputs[3].valueType = ValueType.Float;

            colorInputNode.elements = new NodeUIElements(0, 0, 3);

            colorInputNode.elements.sliders[0] = AddSlider(outputs[1].transform, false);
            colorInputNode.elements.sliders[1] = AddSlider(outputs[2].transform, false);
            colorInputNode.elements.sliders[2] = AddSlider(outputs[3].transform, false);

            PreviewColor(1, 2, 3, false);
            imagePreview.UpdateNodeOnValueChange(colorInputNode.elements.sliders[0], colorInputNode.MoveUp);
            imagePreview.UpdateNodeOnValueChange(colorInputNode.elements.sliders[1], colorInputNode.MoveUp);
            imagePreview.UpdateNodeOnValueChange(colorInputNode.elements.sliders[2], colorInputNode.MoveUp);

            colorInputNode.AddPointers(inputs, outputs);
        }
    }
}
