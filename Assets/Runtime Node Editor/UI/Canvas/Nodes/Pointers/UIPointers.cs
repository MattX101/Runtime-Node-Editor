using RuntimeNodeEditor.UI.Canvas.Node.UI;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Pointer
{
    internal static partial class UIPointers
    {
        internal static GameObject CreatePointer(string name, GameObject parent, Color color, Texture2D texture, int layer, bool pointerIsInput = false, bool createText = false)
        {
            GameObject uiElement = UIElement.Create(
                parent.transform,
                name,
                new Vector2(UISettings.PointerSize, UISettings.PointerSize),
                CalcualtePosition(
                    parent.GetComponent<RectTransform>(),
                    pointerIsInput,
                    layer));

            AddImage(uiElement, texture, color);

            if (createText)
            {
                AddText(uiElement, name, pointerIsInput);
            }

            AddCollider(uiElement);

            return uiElement;
        }

        private static Vector3 CalcualtePosition(RectTransform rect, bool isInput, int layer)
        {
            float posX = rect.sizeDelta.x + UISettings.BorderSize * 2;
            posX = isInput ? -posX : posX;
            posX /= 2;

            float posY = (rect.sizeDelta.y - UISettings.PointerSize) / 2;
            posY -= layer * (UISettings.PointerSize + UISettings.PointerPadding);

            return new Vector3(posX, posY, 0.0f);
        }

        private static void AddCollider(GameObject uiElement)
        {
            RectTransform pointerRect = uiElement.GetComponent<RectTransform>();
            CircleCollider2D circleCollider2D = uiElement.AddComponent<CircleCollider2D>();
            circleCollider2D.radius = pointerRect.rect.width / 2;
        }
    }
}
