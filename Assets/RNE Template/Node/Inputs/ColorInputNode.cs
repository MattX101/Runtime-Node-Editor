using RNE.Template.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node
{
    public class ColorInputNode : RuntimeNodeEditor.Node.Node
    {
        protected override void CodeToExecute()
        {
            Outputs[1].GetComponent<FloatOutputPointer>().Value = Elements.Sliders[0].value;
            Outputs[2].GetComponent<FloatOutputPointer>().Value = Elements.Sliders[1].value;
            Outputs[3].GetComponent<FloatOutputPointer>().Value = Elements.Sliders[2].value;

            Outputs[0].GetComponent<ColorOutputPointer>().Value =
                new Color(
                    Elements.Sliders[0].value,
                    Elements.Sliders[1].value,
                    Elements.Sliders[2].value);
        }

        protected override void CodeToReset()
        {
            Outputs[0].GetComponent<ColorOutputPointer>().Reset();
        }
    }
}
