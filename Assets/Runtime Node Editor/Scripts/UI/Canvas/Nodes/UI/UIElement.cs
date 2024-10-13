using UnityEngine;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIElement
    {
        public static GameObject Create(Transform parent, string name, Vector2 size, Vector3 pos)
        {
            GameObject uiElement = new()
            {
                name = name,
                transform =
                {
                    parent = parent.transform
                }
            };

            RectTransform rect = uiElement.AddComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.sizeDelta = size;
            rect.localPosition = pos;

            return uiElement;
        }
    }
}
