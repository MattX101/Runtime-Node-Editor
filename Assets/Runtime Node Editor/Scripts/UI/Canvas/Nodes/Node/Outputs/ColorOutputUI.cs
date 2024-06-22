using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class ColorOutputUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Color");
            ColorOutputNode colorOutputNode = root.AddComponent<ColorOutputNode>();
            colorOutputNode.endNode = true;

            inputs = new InputPointer[1];
            NumOfInputs = inputs.Length;
            NumOfOutputs = 0;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(colorOutputNode, Color.gray, "Color");
            colorOutputNode.ImagePreview = ImagePreview;

            inputs[0] = CreatePointer("Color", ValueType.Color, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "Color";
            inputs[0].node = colorOutputNode;
            inputs[0].valueType = ValueType.Color;

            colorOutputNode.AddPointers(inputs, outputs);
        }
    }
}
