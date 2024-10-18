using RuntimeNodeEditor.Node.UIFunctions.Component;
using RuntimeNodeEditor.UI.Canvas.Node.UI;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.Pointer
{
    internal static partial class UIPointers
    {
        private static void AddImage(GameObject uiElement, Texture2D texture, Color color)
        {
            UIImage.Create(
                uiElement,
                color
                );
            UIImage.AssignTexture(
                uiElement,
                texture);
        }

        private static void AddText(GameObject uiElement, string name, bool isInput)
        {
            float x = 50;
            x = isInput ? x : -x;

            TextMeshPro text = UIText.CreateText(
                uiElement.transform,
                "Text",
                new Vector2(60, 20),
                new Vector3(x, 0, -1),
                name,
                Color.white);

            UIText.SetFontAlignment(
                text,
                isInput ? TextAlignmentOptions.Left : TextAlignmentOptions.Right);
        }

        internal static BooleanButton AddBooleanPreview(RuntimeNodeEditor.Node.Node node, Transform parent, bool pointerIsInput = false, bool interactable = false)
        {
            BooleanButton button = UIBooleanPreview.Create(parent, interactable);
            UIBooleanPreview.AddOnValueChange(button.Button, node);

            float posX = UISettings.PointerSize * 1.5f;
            posX = pointerIsInput ? posX : -posX;
            button.Button.gameObject.transform.localPosition = new Vector3(posX, 0, -1);

            return button;
        }

        internal static Slider AddLinearSlider(Transform parent, Color color, bool pointerIsInput = false)
        {
            return UISlider.AddLinearSlider(parent, color, pointerIsInput);
        }

        internal static Slider AddIntegerSlider(Transform parent, Color color, int min, int max, bool pointerIsInput = false)
        {
            return UISlider.AddIntegerSlider(parent, color, min, max, pointerIsInput);
        }
    }
}
