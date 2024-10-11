using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIInputField
    {
        public static TMP_InputField Create(Transform parent, bool interactable = true, bool shorten = false, bool halfSize = false)
        {
            // Input Field
            TMP_InputField inputField = AddInputField(parent, "Input Field", interactable, shorten, halfSize);
            inputField.contentType = TMP_InputField.ContentType.Standard;

            return inputField;
        }

        internal static TMP_InputField AddInputField(Transform parent, string name, bool interactable, bool shorten, bool halfSize)
        {
            // Root
            GameObject root = UIElement.Create(parent, name, CalcualteSize(shorten, halfSize), Vector3.zero);
            RectTransform rect = root.GetComponent<RectTransform>();
            UIImage.Create(root, Color.white);

            // Text Area
            GameObject textArea = UIElement.Create(root.transform, "Text Area", Vector2.zero, Vector3.zero);
            RectTransform textAreaRect = textArea.GetComponent<RectTransform>();

            // Text
            TextMeshPro textText = UIText.CreateText(textArea.transform, "Text", rect.sizeDelta, new Vector3(0, 0, -1), "", Color.black);
            UIText.SetTextColor(textText, new Color(0.2f, 0.2f, 0.2f, 1.0f));
            UIText.SetFontAlignment(textText, TextAlignmentOptions.Center);

            textText.gameObject.AddComponent<CanvasRenderer>();

            // Input Field
            TMP_InputField inputField = root.AddComponent<TMP_InputField>();
            inputField.textViewport = textAreaRect;
            inputField.textComponent = textText;
            inputField.interactable = interactable;

            ColorBlock colors = inputField.colors; 
            colors.normalColor = Color.white * 0.9f;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white * 0.9f;
            colors.selectedColor = Color.white * 0.9f;
            colors.disabledColor = Color.white * 0.75f;
            colors.fadeDuration = 0.0f;
            inputField.colors = colors;

            return inputField;
        }

        private static Vector2 CalcualteSize(bool shorten, bool halfSize)
        {
            float width = UISettings.NodeWidth;
            width /= halfSize ? 2 : 1;
            width -= UISettings.PointerSize / 2;
            if (shorten && !halfSize)
                width -= UISettings.PointerSize / 2;
            width -= UISettings.PointerPadding * 2;

            return new Vector2(width, UISettings.InputFieldHeight);
        }

        public static void SetSingleCharacterInputField(TMP_InputField inputField)
        {
            inputField.onValueChanged.AddListener(
                delegate
                {
                    UpdateCharacter(inputField);
                });
        }

        public static void AddOnValueChange(TMP_InputField inputField, Nodes.Node.Node node)
        {
            inputField.onValueChanged.AddListener(
                delegate
                {
                    node.OnValueChangeReset();
                });
        }

        private static void UpdateCharacter(TMP_InputField inputField)
        {
            if (inputField.text.Length == 0)
                return;

            char character = inputField.text[^1];
            inputField.text = character.ToString();
        }
    }
}
