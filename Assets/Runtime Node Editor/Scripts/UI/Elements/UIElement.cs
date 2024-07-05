using UnityEngine;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIElement
    {
        public static GameObject Create(Transform parent, string name)
        {
            return Create(parent, name, Vector2.one, Vector3.zero);
        }
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

        public static void SetAnchor(GameObject uiElement, Vector2 min, Vector2 max)
        {
            RectTransform rect = uiElement.GetComponent<RectTransform>();
            rect.anchorMin = min;
            rect.anchorMax = max;
        }

        public static void SetPivot(GameObject uiElement, Vector2 pivot)
        {
            RectTransform rect = uiElement.GetComponent<RectTransform>();
            rect.pivot = pivot;
        }

        public static void UpdateOffset(GameObject uiElement, Vector2 min, Vector2 max)
        {
            RectTransform rect = uiElement.GetComponent<RectTransform>();

            rect.offsetMin = min;
            rect.offsetMax = max;
        }
    }
}
