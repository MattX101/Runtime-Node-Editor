using UnityEngine;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIElement
    {
        public static GameObject CreateUIElement(Transform parent, string objectName, Vector2 size, Vector3 pos)
        {
            GameObject uiElement = new GameObject();
            uiElement.name = objectName;
            uiElement.transform.parent = parent.transform;

            RectTransform rect = uiElement.AddComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.sizeDelta = size;
            rect.localPosition = pos;

            return uiElement;
        }

        public static void UpdateUIElement(RectTransform rect, Vector2 size, Vector3 pos)
        {
            rect.sizeDelta = size;
            rect.localPosition = pos;
        }
    }
}
