using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static partial class UISlider
    {
        private static TextMeshPro CreateTextField(Transform parent)
        {
            Vector2 scale = new Vector2(UISettings.SliderTextFieldWidth, UISettings.PointerSize);

            // Text Field
            GameObject textPreviewObject = UIElement.Create(
                parent,
                "Value Preview",
                scale,
                new Vector3(PosX, 0, 0));

            UIImage.Create(textPreviewObject, Color.white);

            return AddText(textPreviewObject, scale);
        }

        private static TextMeshPro AddText(GameObject textPreviewObject, Vector2 scale)
        {
            TextMeshPro text = UIText.CreateText(
                textPreviewObject.transform,
                "Text",
                scale,
                new Vector3(0, 0, -1),
                "0.5",
                Color.black);

            UIText.SetFontAlignment(text, TextAlignmentOptions.Center);

            return text;
        }

        private static float PosX
        {
            get
            {
                return UISettings.NodeWidth + (UISettings.PointerSize / 4) - UISettings.SliderTextFieldWidth - (UISettings.BorderSize * 2);
            }
        }
    }
}
