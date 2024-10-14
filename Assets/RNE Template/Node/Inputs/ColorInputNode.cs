using RNE.Template.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node
{
    public class ColorInputNode : RuntimeNodeEditor.Node.Node.Node
    {
        protected override void CodeToExecute()
        {
            outputs[1].GetComponent<FloatOutputPointer>().value = Elements.Sliders[0].value;
            outputs[2].GetComponent<FloatOutputPointer>().value = Elements.Sliders[1].value;
            outputs[3].GetComponent<FloatOutputPointer>().value = Elements.Sliders[2].value;

            outputs[0].GetComponent<ColorOutputPointer>().value =
                new Color(
                    Elements.Sliders[0].value,
                    Elements.Sliders[1].value,
                    Elements.Sliders[2].value);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<ColorOutputPointer>().Reset();
        }
    }
}
