using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorLerpNode : Node
    {
        public ImagePreview ImagePreview;

        public override void Execute()
        {
            Color a = Color.black;
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer inputA))
            {
                if (inputA.connectedOutputPointer)
                {
                    inputA.connectedOutputPointer.node.Execute();
                    a = PointerValue.GetColor(inputA.connectedOutputPointer);
                }
            }

            Color b = Color.black;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer inputB))
            {
                if (inputB.connectedOutputPointer)
                {
                    inputB.connectedOutputPointer.node.Execute();
                    b = PointerValue.GetColor(inputB.connectedOutputPointer);
                }
            }

            float t = 0.5f;
            if (inputs[2].TryGetComponent(out SingleConnectionInputPointer inputT))
            {
                if (inputT.connectedOutputPointer)
                {
                    inputT.connectedOutputPointer.node.Execute();
                    t = PointerValue.GetFloat(inputT.connectedOutputPointer);
                }
            }

            outputs[0].GetComponent<ColorOutputPointer>().value = Color.Lerp(a, b, t);
            ImagePreview.Image.color = outputs[0].GetComponent<ColorOutputPointer>().value;

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<ColorOutputPointer>().Reset();
        }
    }
}