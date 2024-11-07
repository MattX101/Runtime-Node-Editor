using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static class UILayer
    {
        public static GameObject CreateLayer(string name, Transform parent, int layer = 0)
        {
            return UIElement.Create(
                parent,
                name,
                new Vector2(GlobalData.NodeWidth - (GlobalData.BorderSize * 2), GlobalData.PointerSize),
                CalcualtePosition(
                    parent.GetComponent<RectTransform>(),
                    layer)
                );
        }

        private static Vector3 CalcualtePosition(RectTransform rect, int layer)
        {
            float posY = (rect.sizeDelta.y - GlobalData.PointerSize) / 2;
            posY -= layer * (GlobalData.PointerSize + GlobalData.PointerPadding);

            return new (0.0f, posY, 0.0f);
        }
    }
}