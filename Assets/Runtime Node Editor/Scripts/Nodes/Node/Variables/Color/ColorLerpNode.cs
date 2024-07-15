using RuntimeNodeEditor.Functions.UI.Component;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorLerpNode : Node
    {
        public ImagePreview ImagePreview;

        public override void Execute()
        {
            Color a = Color.black;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                a = inputs[0].connectedOutputPointer.Data.ColorValue;
            }

            Color b = Color.black;
            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                b = inputs[1].connectedOutputPointer.Data.ColorValue;
            }

            float t = 0.5f;
            if (inputs[2].connectedOutputPointer)
            {
                inputs[2].connectedOutputPointer.node.Execute();
                t = inputs[2].connectedOutputPointer.Data.FloatValue;
            }

            outputs[0].Data.ColorValue = Color.Lerp(a, b, t);
            ImagePreview.Image.color = outputs[0].Data.ColorValue;

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.ColorValue = Color.black;
        }
    }
}