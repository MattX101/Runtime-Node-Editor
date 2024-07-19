using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorInputNode : Node
    {
        public override void Execute()
        {
            outputs[1].GetComponent<FloatOutputPointer>().value = Elements.Sliders[0].value;
            outputs[2].GetComponent<FloatOutputPointer>().value = Elements.Sliders[1].value;
            outputs[3].GetComponent<FloatOutputPointer>().value = Elements.Sliders[2].value;

            outputs[0].GetComponent<ColorOutputPointer>().value =
                new Color(
                    Elements.Sliders[0].value,
                    Elements.Sliders[1].value,
                    Elements.Sliders[2].value);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<ColorOutputPointer>().Reset();
        }
    }
}
