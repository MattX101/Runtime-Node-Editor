using RuntimeNodeEditor.UI.Elements;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes
{
    internal static class UILayer
    {
        internal static GameObject CreateLayer(string name, Transform parent, int layer = 0)
        {
            return UIElement.Create(
                parent,
                name,
                new Vector2(UISettings.NodeWidth - (UISettings.BorderSize * 2), UISettings.PointerSize),
                CalcualtePosition(
                    parent.GetComponent<RectTransform>(),
                    layer)
                );
        }

        private static Vector3 CalcualtePosition(RectTransform rect, int layer)
        {
            float posY = (rect.sizeDelta.y - UISettings.PointerSize) / 2;
            posY -= layer * (UISettings.PointerSize + UISettings.PointerPadding);

            return new (0.0f, posY, 0.0f);
        }
    }
}