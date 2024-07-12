using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIInputField
    {
        public static TMP_InputField Create(Transform parent, TMP_InputField.ContentType contentType, bool interactable = true, bool shorten = false, bool halfSize = false)
        {
            float width = halfSize ? UISettings.NodeWidth / 2 : UISettings.NodeWidth;
            Vector2 size = new Vector2(
                shorten ? width - UISettings.PointerSize * 1.5f : width - UISettings.PointerSize, 
                UISettings.InputFieldHeight);

            // Root
            GameObject root = UIElement.Create(parent, "Input Field", size, Vector3.zero);
            RectTransform rect = root.GetComponent<RectTransform>();
            UIImage.Create(root, Color.white);

            // Text Area
            GameObject textArea = UIElement.Create(root.transform, "Text Area", Vector2.zero, Vector3.zero);
            RectTransform textAreaRect = textArea.GetComponent<RectTransform>();

            // Text
            TextMeshPro textText = UIText.CreateText(textArea.transform, "Text", rect.sizeDelta, new Vector3(0, 0, -1), "");
            UIText.SetTextColor(textText, new Color(0.2f, 0.2f, 0.2f, 1.0f));
            UIText.SetFontAlignment(textText, TextAlignmentOptions.Center);

            textText.gameObject.AddComponent<CanvasRenderer>();

            // Input Field
            TMP_InputField inputField = root.AddComponent<TMP_InputField>();
            inputField.textViewport = textAreaRect;
            inputField.textComponent = textText;
            inputField.interactable = interactable;
            inputField.contentType = contentType;

            return inputField;
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
                    node.MoveUp();
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
