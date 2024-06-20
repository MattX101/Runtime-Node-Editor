using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIInputField
    {
        public static TMP_InputField Create(Transform parent, TMP_InputField.ContentType contentType, bool interactable)
        {
            // Root
            GameObject root = UIElement.Create(parent, "Input Field", new Vector2(UISettings.nodeWidth - UISettings.pointerSize, UISettings.inputFieldHeight), Vector3.zero);
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

        public static void AddOnValueChange(TMP_InputField inputField, RuntimeNodeEditor.Nodes.Node.Node node)
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
