using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Node.Component
{
    public class ImagePreview
    {
        public RawImage image;

        public void SetSliderInput(Slider red, Slider green, Slider blue)
        {
            if (red == null || green == null || blue == null)
            {
                Debug.LogError("One or more of the sliders are null");
            }
            else
            {
                image.color = new Color(
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
        }

        private void SetR(Slider red)
        {
            image.color = new Color(
                red.value,
                image.color.g,
                image.color.b, 
                1);
        }
        private void SetG(Slider green)
        {
            image.color = new Color(
                image.color.r, 
                green.value,
                image.color.b, 
                1);
        }
        private void SetB(Slider blue)
        {
            image.color = new Color(
                image.color.r,
                image.color.g, 
                blue.value, 
                1);
        }

        public void UpdateNodeOnValueChange(Slider slider, Node node)
        {
            slider.onValueChanged.AddListener(
                delegate
                {
                    node.MoveUp();
                });
        }
    }
}
