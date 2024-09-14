using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UISlider
    {
        public static GameObject Create(Transform root)
        {
            // Root
            GameObject rootObject = UIElement.Create(
                root,
                "Slider Element",
                Vector2.zero,
                new Vector3(
                    -UISettings.NodeWidth + UISettings.BorderSize, 
                    0, 
                    -1)
                );

            CreateBackground(rootObject.transform);

            return rootObject;
        }

        private static void CreateBackground(Transform parent)
        {
            // Background
            float scaleX = UISettings.NodeWidth;
            scaleX -= UISettings.PointerSize / 2;
            scaleX -= UISettings.BorderSize * 4;

            GameObject background = UIElement.Create(
                parent,
                "Background",
                new Vector2(scaleX, UISettings.PointerSize),
                new Vector3(scaleX / 2, 0, 0));

            RawImage backgroundImage = background.AddComponent<RawImage>();
            backgroundImage.color = Color.white * 0.75f;
        }

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
                    UpdateTextFieldValue(slider, text);
                });
        }

        private static Slider CreateSliderComponent(Transform parent)
        {
            // Slider
            float scaleX = UISettings.NodeWidth;
            scaleX -= UISettings.PointerSize / 2;
            scaleX -= UISettings.SliderHandleWidth;
            scaleX -= UISettings.SliderTextFieldWidth;
            scaleX -= UISettings.BorderSize * 2;

            GameObject sliderObject = UIElement.Create(
                parent,
                "Slider",
                new Vector2(scaleX, UISettings.PointerSize),
                new Vector3(scaleX / 2, 0, 0));

            // Fill
            GameObject fill = UIElement.Create(
                sliderObject.transform,
                "Fill",
                Vector2.zero,
                Vector3.zero);

            UIImage.Create(fill, Color.white);

            // Handle
            GameObject handle = UIElement.Create(
                sliderObject.transform,
                "Handle",
                new Vector2(UISettings.SliderHandleWidth, 0),
                new Vector3(UISettings.SliderHandleWidth / 2, 0, 0));

            RawImage handleImage = UIImage.Create(handle, Color.white);

            // Slider Component
            Slider slider = sliderObject.AddComponent<Slider>();
            slider.interactable = true;
            slider.targetGraphic = handleImage;

            slider.fillRect = fill.GetComponent<RectTransform>();
            slider.handleRect = handle.GetComponent<RectTransform>();

            slider.direction = Slider.Direction.LeftToRight;
            slider.minValue = 0;
            slider.maxValue = 1;
            slider.value = 0;

            return slider;
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

        private static TextMeshPro CreateTextField(Transform parent)
        {
            Vector2 scale = new Vector2(UISettings.SliderTextFieldWidth, UISettings.PointerSize);

            // Text Field
            float posX = UISettings.NodeWidth;
            posX += UISettings.PointerSize / 4;
            posX -= UISettings.SliderTextFieldWidth;
            posX -= UISettings.BorderSize * 2;

            GameObject valuePreviewObject = UIElement.Create(
                parent,
                "Value Preview",
                scale,
                new Vector3(posX, 0, 0));

            UIImage.Create(valuePreviewObject, Color.white);

            // Text
            TextMeshPro text = UIText.CreateText(
                valuePreviewObject.transform,
                "Text",
                scale,
                new Vector3(0, 0, -1),
                "0.5",
                Color.black);
            UIText.SetFontAlignment(text, TextAlignmentOptions.Center);

            return text;
        }

        private static void UpdateTextFieldValue(Slider slider, TextMeshPro text)
        {
            string value = slider.value.ToString();
            value = ProcessSliderValue(value);

            text.text = value;
        }
    }
}
