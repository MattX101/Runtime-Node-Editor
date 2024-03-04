using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIText
    {
        public static TextMeshPro CreateText(Transform parent, string textObjectName, Vector2 size, Vector3 pos, string textString)
        {
            GameObject textObject = UIElement.CreateUIElement(parent, textObjectName, size, pos);

            TextMeshPro text = textObject.AddComponent<TextMeshPro>();
            text.text = textString;
            text.color = Color.black;
            text.enableAutoSizing = true;
            text.fontSizeMin = 1.0f;
            text.fontSizeMax = 1000.0f;

            return text;
        }
    }
}
