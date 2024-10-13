using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static partial class UISlider
    {
        private static Slider CreateIntegerSlider(Transform parent, int min, int max, Color color)
        {
            Slider slider = CreateSliderComponent(parent, color);

            AddOnValueChange_Integer(
                slider,
                CreateSliderText(parent, min),
                min,
                max);

            return slider;
        }

        private static void AddOnValueChange_Integer(Slider slider, TextMeshPro text, int min, int max)
        {
            slider.onValueChanged.AddListener(
                delegate
                {
                    UpdateTextOnValueChange_Integer(text, slider.value, min, max);
                });
        }

        private static void UpdateTextOnValueChange_Integer(TextMeshPro text, float value, int max)
        {
            UpdateTextOnValueChange_Integer(text, value, 0, max);
        }

        private static void UpdateTextOnValueChange_Integer(TextMeshPro text, float value, int min, int max)
        {
            text.text = ProcessSliderValue(
                Mathf.FloorToInt(Mathf.Lerp(min, max, value)).ToString()
                );
        }
    }
}
