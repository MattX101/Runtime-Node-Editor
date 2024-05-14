using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class ColorOutputUI : NodeUI
    {
        public ColorOutputUI() : base("ColorOutputUI")
        {
            CreateRoot("Color");
            ColorOutputNode colorOutputNode = root.AddComponent<ColorOutputNode>();
            colorOutputNode.endNode = true;
            colorOutputNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            drawBodyImage = false;
            togglePreviewImage = true;

            CreateNodeUI(colorOutputNode, Color.gray, "Color");

            inputs[0] = CreatePointer("Color", ValueType.Color, 0, false, true).AddComponent<InputPointer>();
            inputs[0].name = "Color";
            inputs[0].node = colorOutputNode;
            inputs[0].valueType = ValueType.Color;

            colorOutputNode.AddPointers(inputs, outputs);
        }
    }
}
