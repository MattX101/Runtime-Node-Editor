using UnityEngine;
using TMPro;
using RuntimeNodeEditor.Data;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static partial class UISlider
    {
        private static TextMeshPro CreateTextField(Transform parent)
        {
            Vector2 scale = new Vector2(GlobalData.SliderTextFieldWidth, GlobalData.PointerSize);

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
                return GlobalData.NodeWidth + (GlobalData.PointerSize / 4) - GlobalData.SliderTextFieldWidth - (GlobalData.BorderSize * 2);
            }
        }
    }
}
