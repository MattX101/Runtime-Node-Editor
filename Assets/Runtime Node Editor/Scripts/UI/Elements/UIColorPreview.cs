using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Node
{
    public class UIColorPreview
    {
        private RawImage _image;

        public UIColorPreview(RawImage image, Slider red, Slider green, Slider blue)
        {
            if (image == null)
            {
                Debug.LogError("Image cannot be null");
            }
            else
            {
                if (red == null || green == null || blue == null)
                {
                    Debug.LogError("One or more of the sliders are null");
                }
                else
                {
                    _image = image;
                    _image.color = new Color(
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
        }

        private void SetR(Slider red)
        {
            _image.color = new Color(
                red.value,
                _image.color.g,
                _image.color.b, 
                1);
        }
        private void SetG(Slider green)
        {
            _image.color = new Color(
                _image.color.r, 
                green.value,
                _image.color.b, 
                1);
        }
        private void SetB(Slider blue)
        {
            _image.color = new Color(
                _image.color.r,
                _image.color.g, 
                blue.value, 
                1);
        }
    }
}
