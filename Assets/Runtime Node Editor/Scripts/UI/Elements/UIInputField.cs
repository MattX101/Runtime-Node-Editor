using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIInputField
    {
        public static TMP_InputField CreateInputField(Transform parent, TMP_InputField.ContentType contentType, bool interactable)
        {
            // Root
            GameObject root = UIElement.CreateUIElement(parent, "Input Field", new Vector2(UISettings.nodeWidth - UISettings.pointerSize, UISettings.inputFieldHeight), Vector3.zero);
            RectTransform rect = root.GetComponent<RectTransform>();
            UIImage.CreateRawImage(root, Color.white);

            // Text Area
            GameObject textArea = UIElement.CreateUIElement(root.transform, "Text Area", Vector2.zero, Vector3.zero);
            RectTransform textAreaRect = textArea.GetComponent<RectTransform>();

            // Text
            TextMeshPro textText = UIText.CreateText(textArea.transform, "Text", rect.sizeDelta, new Vector3(0, 0, -1), "");
            UIText.SetTextColor(textText, new Color(0.2f, 0.2f, 0.2f, 1.0f));
            UIText.SetFontAligment(textText, TextAlignmentOptions.Center);

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
                    SetSingle(inputField);
                });
        }

        public static void UpdateNodeOnValueChange(TMP_InputField inputField, RuntimeNodeEditor.Node.Node node)
        {
            inputField.onValueChanged.AddListener(
                delegate
                {
                    node.MoveUp();
                });
        }

        private static void SetSingle(TMP_InputField inputField)
        {
            if (inputField.text.Length > 1)
            {
                char character = inputField.text[inputField.text.Length - 1];

                inputField.text = "";
                inputField.text += character;
            }
        }
    }
}
