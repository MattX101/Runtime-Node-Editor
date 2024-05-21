using RuntimeNodeEditor.UI.Elements;
using TMPro;  
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Node
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
                    -UISettings.nodeWidth + UISettings.borderSize, 
                    0, 
                    -1)
                );

            CreateBackground(rootObject.transform);

            return rootObject;
        }

        private static void CreateBackground(Transform parent)
        {
            // Background
            float scaleX = UISettings.nodeWidth;
            scaleX -= UISettings.pointerSize / 2;
            scaleX -= UISettings.borderSize * 4;

            GameObject background = UIElement.Create(
                parent,
                "Background",
                new Vector2(scaleX, UISettings.pointerSize),
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
            float scaleX = UISettings.nodeWidth;
            scaleX -= UISettings.pointerSize / 2;
            scaleX -= UISettings.sliderHandleWidth;
            scaleX -= UISettings.sliderTextFieldWidth;
            scaleX -= UISettings.borderSize * 2;

            GameObject sliderObject = UIElement.Create(
                parent,
                "Slider",
                new Vector2(scaleX, UISettings.pointerSize),
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
                new Vector2(UISettings.sliderHandleWidth, 0),
                new Vector3(UISettings.sliderHandleWidth / 2, 0, 0));

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
            if (value.Length > 4)
                value = value.Substring(0, 4);
            else if (value.Length == 1)
                value += ".00";

            return value;
        }

        private static TextMeshPro CreateTextField(Transform parent)
        {
            Vector2 scale = new Vector2(UISettings.sliderTextFieldWidth, UISettings.pointerSize);

            // Text Field
            float posX = UISettings.nodeWidth;
            posX += UISettings.pointerSize / 4;
            posX -= UISettings.sliderTextFieldWidth;
            posX -= UISettings.borderSize * 2;

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
                "0.5");
            UIText.SetFontAligment(text, TextAlignmentOptions.Center);

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
