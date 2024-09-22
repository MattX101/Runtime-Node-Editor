using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Elements
{
    public partial class NodeUIElements
    {
        public readonly Slider[] Sliders;

        public void SetSlider(Slider slider, float value)
        {
            slider.value = value;
        }

        private void SetSliders(float[] values)
        {
            if (Sliders == null)
                return;

            for (int i = 0; i < Sliders.Length; i++)
                SetSlider(Sliders[i], values[i]);
        }
        private void SetSliders(Slider[] values)
        {
            if (Sliders == null)
                return;

            for (int i = 0; i < Sliders.Length; i++)
                SetSlider(Sliders[i], values[i].value);
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
