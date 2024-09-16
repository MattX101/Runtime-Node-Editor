using UnityEngine;
using TMPro;
using System;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIInputField
    {
        public static TMP_InputField Create(Transform parent, TMP_InputField.ContentType contentType, bool interactable = true, bool shorten = false, bool halfSize = false)
        {
            float width = UISettings.NodeWidth;
            width /= halfSize ? 2 : 1;
            width -= UISettings.PointerSize / 2;
            if (shorten && !halfSize)
                width -= UISettings.PointerSize / 2;
            width -= UISettings.PointerPadding * 2;
            Vector2 size = new Vector2(width,  UISettings.InputFieldHeight);

            // Root
            GameObject root = UIElement.Create(parent, "Input Field", size, Vector3.zero);
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
                    ValidateInputField(inputField);
                    node.OnValueChangeReset();
                });
        }

        private static void ValidateInputField(TMP_InputField inputField)
        {
            if (inputField.text.Length == 0)
                return;

            if (inputField.text.Length == 1 && inputField.text[0] == '-')
                return;

            if (inputField.contentType == TMP_InputField.ContentType.IntegerNumber)
            {
                try
                {
                    int.Parse(inputField.text);
                }
                catch (OverflowException)
                {
                    inputField.text =
                        inputField.text[0] == '-' ?
                        int.MinValue.ToString() :
                        int.MaxValue.ToString();
                }
            }
            else if (inputField.contentType == TMP_InputField.ContentType.DecimalNumber)
            {
                try
                {
                    float.Parse(inputField.text);
                }
                catch (OverflowException)
                {
                    inputField.text =
                        inputField.text[0] == '-' ?
                        float.MinValue.ToString() :
                        float.MaxValue.ToString();
                }
            }
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
