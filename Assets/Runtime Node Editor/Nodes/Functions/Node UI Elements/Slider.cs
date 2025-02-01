using Utils.IO.Serialization;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Node.UI.Functions.Elements
{
    public partial class NodeUIElements
    {
        public Slider[] sliders;

        public void SetSlider(Slider slider, float value)
        {
            slider.value = value;
        }

        private void SetSliders(float[] values)
        {
            if (sliders == null)
                return;

            for (int i = 0; i < sliders.Length; i++)
            {
                SetSlider(sliders[i], values[i]);
            }
        }
        private void SetSliders(Slider[] values)
        {
            if (sliders == null)
                return;

            for (int i = 0; i < sliders.Length; i++)
            {
                SetSlider(sliders[i], values[i].value);
            }
        }

        private void SaveSliders(FileWriter writer, Slider[] sliders)
        {
            writer.Write((byte)sliders.Length);

            if (sliders.Length > 0)
            {
                for (int i = 0; i < sliders.Length; i++)
                {
                    writer.Write(sliders[i].value);
                }
            }
        }
    }
}
