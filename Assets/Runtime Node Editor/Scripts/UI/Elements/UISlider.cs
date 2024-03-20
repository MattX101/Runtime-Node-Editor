using RuntimeNodeEditor.UI.Elements;
using TMPro;  
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Node
{
    public static class UISlider
    {
        public static GameObject CreateElement(Transform root)
        {
            // Root
            float posX = -UISettings.nodeWidth + UISettings.borderSize;

            GameObject rootObject = UIElement.CreateUIElement(
                root,
                "Slider Element",
                new Vector2(0, 0),
                new Vector3(posX, 0, -1));

            CreateBackground(rootObject.transform);

            return rootObject;
        }

        public static Slider CreateSliderElement(Transform parent)
        {
            Slider slider = CreateSlider(parent);
            TextMeshPro text = CreateTextField(parent);

            text.text = ProcessSliderValue(slider.value.ToString());
            AddListerner(slider, text);

            return slider;
        }

        private static void AddListerner(Slider slider, TextMeshPro text)
        {
            slider.onValueChanged.AddListener(
                delegate
                {
                    UpdateTextFieldValue(slider, text);
                });
        }

        private static void CreateBackground(Transform parent)
        {
            // Background
            float scaleX = UISettings.nodeWidth;
            scaleX -= UISettings.pointerSize / 2;
            scaleX -= UISettings.borderSize * 4;

            float posX = scaleX / 2;

            GameObject background = UIElement.CreateUIElement(
                parent,
                "Background",
                new Vector2(scaleX, UISettings.pointerSize),
                new Vector3(posX, 0, 0));

            RawImage backgroundImage = background.AddComponent<RawImage>();
            backgroundImage.color = Color.white * 0.75f;
        }

        private static Slider CreateSlider(Transform parent)
        {
            // Slider
            float scaleX = UISettings.nodeWidth;
            scaleX -= UISettings.pointerSize / 2;
            scaleX -= UISettings.sliderHandleWidth;
            scaleX -= UISettings.sliderTextFieldWidth;
            scaleX -= UISettings.borderSize * 2;

            float posX = scaleX / 2;

            GameObject sliderObject = UIElement.CreateUIElement(
                parent,
                "Slider",
                new Vector2(scaleX, UISettings.pointerSize),
                new Vector3(posX, 0, 0));

            // Fill
            GameObject fill = UIElement.CreateUIElement(
                sliderObject.transform,
                "Fill",
                Vector2.zero,
                Vector3.zero);

            RawImage fillImage = fill.AddComponent<RawImage>();
            fillImage.color = Color.white;

            // Handle
            GameObject handle = UIElement.CreateUIElement(
                sliderObject.transform,
                "Handle",
                new Vector2(UISettings.sliderHandleWidth, 0),
                new Vector3(UISettings.sliderHandleWidth / 2, 0, 0));

            RawImage handleImage = handle.AddComponent<RawImage>();
            handleImage.color = Color.white;

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

        private static TextMeshPro CreateTextField(Transform parent)
        {
            Vector2 scale = new Vector2(UISettings.sliderTextFieldWidth, UISettings.pointerSize);

            // Text Field
            float posX = UISettings.nodeWidth;
            posX += UISettings.pointerSize / 4;
            posX -= UISettings.sliderTextFieldWidth;
            posX -= UISettings.borderSize * 2;

            GameObject valuePreviewObject = UIElement.CreateUIElement(
                parent,
                "Value Preview",
                scale,
                new Vector3(posX, 0, 0));

            RawImage valuePreviewImage = valuePreviewObject.AddComponent<RawImage>();
            valuePreviewImage.color = Color.white;

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

        private static string ProcessSliderValue(string value)
        {
            if (value.Length > 4)
                value = value.Substring(0, 4);
            else if (value.Length == 1)
                value += ".00";

            return value;
        }
    }
}
