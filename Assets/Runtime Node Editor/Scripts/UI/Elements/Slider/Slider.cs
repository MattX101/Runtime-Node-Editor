using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static partial class UISlider
    {
        public static Slider CreateSlider(Transform parent)
        {
            Slider slider = CreateSliderComponent(parent);

            TextMeshPro text = CreateTextField(parent);
            text.text = ProcessSliderValue(slider.value.ToString());

            AddOnValueChange(slider, text);

            return slider;
        }

        private static void AddOnValueChange(Slider slider, TextMeshPro text)
        {
            slider.onValueChanged.AddListener(
                delegate
                {
                    UpdateTextOnValueChange(text, slider.value);
                });
        }

        private static Slider CreateSliderComponent(Transform parent)
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
            UIImage.Create(fillObject, Color.white);

            // Handle
            GameObject handleObject = UIElement.Create(
                sliderObject.transform,
                "Handle",
                new Vector2(UISettings.SliderHandleWidth, 0),
                new Vector3(UISettings.SliderHandleWidth / 2, 0, 0));

            return AddSliderComponent(
                sliderObject.AddComponent<Slider>(), 
                fillObject.GetComponent<RectTransform>(), 
                handleObject.GetComponent<RectTransform>()
            );
        }

        private static Slider AddSliderComponent(Slider slider, RectTransform fill, RectTransform handle)
        {
            slider.interactable = true;
            slider.targetGraphic = UIImage.Create(handle.gameObject, Color.white);

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

        private static void UpdateTextOnValueChange(TextMeshPro text, float value)
        {
            text.text = ProcessSliderValue(value.ToString());
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
