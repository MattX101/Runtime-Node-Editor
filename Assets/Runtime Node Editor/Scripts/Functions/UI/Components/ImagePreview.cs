using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Component
{
    public class ImagePreview
    {
        public RawImage Image { get; set; }

        public void SetSliderInput(Slider red, Slider green, Slider blue)
        {
            if (!red || !green || !blue)
            {
                Debug.LogError("One or more of the _sliders are null");

                return;
            }

            Image.color = new Color(
                red.value,
                green.value,
                blue.value,
                1);

            red.onValueChanged.AddListener(
            delegate
            {
                SetR(red);
            });

            green.onValueChanged.AddListener(
            delegate
            {
                SetG(green);
            });

            blue.onValueChanged.AddListener(
            delegate
            {
                SetB(blue);
            });
        }

        private void SetR(Slider red)
        {
            Image.color = new Color(
                red.value,
                Image.color.g,
                Image.color.b, 
                1);
        }
        private void SetG(Slider green)
        {
            Image.color = new Color(
                Image.color.r, 
                green.value,
                Image.color.b, 
                1);
        }
        private void SetB(Slider blue)
        {
            Image.color = new Color(
                Image.color.r,
                Image.color.g, 
                blue.value, 
                1);
        }

        public void UpdateNodeOnValueChange(Slider slider, Func<int> MoveUp)
        {
            slider.onValueChanged.AddListener(
                delegate
                {
                    MoveUp();
                });
        }
    }
}
