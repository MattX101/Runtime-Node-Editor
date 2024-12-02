using System;
using System.Collections.Generic;
using System.Linq;
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

        private List<byte> SaveSliders(List<byte> bytes, Slider[] sliders)
        {
            if (sliders.Length == 0)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)sliders.Length);
            bytes.AddRange(sliders.SelectMany(slider => BitConverter.GetBytes(slider.value)));

            return bytes;
        }
    }
}
