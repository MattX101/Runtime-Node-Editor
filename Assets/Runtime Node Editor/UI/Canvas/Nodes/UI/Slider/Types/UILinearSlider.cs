using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static partial class UISlider
    {
        private static Slider CreateLinearSlider(Transform parent, Color color)
        {
            Slider slider = CreateSliderComponent(parent, color);

            AddOnValueChange_Linear(
                slider,
                CreateSliderText(parent, 0.0f));

            return slider;
        }

        private static void AddOnValueChange_Linear(Slider slider, TextMeshPro text)
        {
            slider.onValueChanged.AddListener(
                delegate
                {
                    UpdateTextOnValueChange_Linear(text, slider.value);
                });
        }

        private static void UpdateTextOnValueChange_Linear(TextMeshPro text, float value)
        {
            text.text = ProcessSliderValue(value.ToString());
        }
    }
}
