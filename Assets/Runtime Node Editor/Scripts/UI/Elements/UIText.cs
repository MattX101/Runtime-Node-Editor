using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIText
    {
        public static TextMeshPro CreateText(Transform parent, string title, Vector2 size, Vector3 pos, string textString, Color textColor)
        {
            GameObject textObject = UIElement.Create(parent, title, size, pos);

            TextMeshPro text = textObject.AddComponent<TextMeshPro>();
            text.text = textString;
            text.color = textColor;
            text.enableAutoSizing = true;
            text.fontSizeMin = 1.0f;
            text.fontSizeMax = 1000.0f;

            return text;
        }

        public static void SetTextColor(TextMeshPro text, Color color)
        {
            text.color = color;
        }

        public static void SetFontStyle(TextMeshPro text, FontStyles style)
        {
            text.fontStyle = style;
        }

        public static void SetFontAlignment(TextMeshPro text, TextAlignmentOptions alignment)
        {
            text.alignment = alignment;
        }
    }
}
