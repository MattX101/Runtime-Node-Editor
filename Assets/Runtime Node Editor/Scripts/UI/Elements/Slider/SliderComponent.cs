using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static partial class UISlider
    {
        private static TextMeshPro CreateSliderText(Transform parent, float value)
        {
            TextMeshPro text = CreateTextField(parent);
            text.text = ProcessSliderValue(value.ToString());

            return text;
        }

        private static Slider CreateSliderComponent(Transform parent, Color color)
        {
            // Slider
            float scaleX = ScaleX;

            GameObject sliderObject = UIElement.Create(
                parent,
                "Slider",
                new Vector2(scaleX, UISettings.PointerSize),
                new Vector3(scaleX / 2, 0, 0));

            // Fill
            GameObject fillObject = UIElement.Create(
                sliderObject.transform,
                "Fill",
                Vector2.zero,
                Vector3.zero);
            UIImage.Create(fillObject, color);

            // Handle
            GameObject handleObject = UIElement.Create(
                sliderObject.transform,
                "Handle",
                new Vector2(UISettings.SliderHandleWidth, 0),
                new Vector3(UISettings.SliderHandleWidth / 2, 0, 0));

            return AddSliderComponent(
                sliderObject.AddComponent<Slider>(),
                color,
                fillObject.GetComponent<RectTransform>(), 
                handleObject.GetComponent<RectTransform>()
            );
        }

        private static Slider AddSliderComponent(Slider slider, Color color, RectTransform fill, RectTransform handle)
        {
            slider.interactable = true;
            slider.targetGraphic = UIImage.Create(handle.gameObject, color * 0.9f);

            slider.fillRect = fill.GetComponent<RectTransform>();
            slider.handleRect = handle.GetComponent<RectTransform>();

            slider.direction = Slider.Direction.LeftToRight;
            slider.minValue = 0;
            slider.maxValue = 1;
            slider.value = 0;

            return slider;
        }

        private static float ScaleX
        {
            get
            {
                return UISettings.NodeWidth - (UISettings.PointerSize / 2) - UISettings.SliderHandleWidth - UISettings.SliderTextFieldWidth - (UISettings.BorderSize * 2);
            }
        }

        private static string ProcessSliderValue(string value)
        {
            switch (value.Length)
            {
                case > 4:
                    value = value[..4];
                    break;
                //value = value.Substring(0, 4);
                case 1:
                    value += ".00";
                    break;
            }

            return value;
        }
    }
}
