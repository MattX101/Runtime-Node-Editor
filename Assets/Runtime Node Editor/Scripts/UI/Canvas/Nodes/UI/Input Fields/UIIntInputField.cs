using UnityEngine;
using System;
using TMPro;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIIntInputField
    {
        public static TMP_InputField Create(Transform parent, bool interactable = true, bool shorten = false, bool halfSize = false)
        {
            // Input Field
            TMP_InputField inputField = UIInputField.AddInputField(parent, "Int Input Field", interactable, shorten, halfSize);
            inputField.contentType = TMP_InputField.ContentType.IntegerNumber;

            return inputField;
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

        public static void AddValueRange(TMP_InputField inputField, int min, int max)
        {
            inputField.onValueChanged.AddListener(
                delegate
                {
                    ClampInput(inputField, min, max);
                });
        }

        private static void ClampInput(TMP_InputField inputField, int min, int max)
        {
            if (inputField.text.Length == 0)
                return;

            if (inputField.text.Length == 1 && inputField.text[0] == '-')
                return;

            inputField.text = Mathf.Clamp(int.Parse(inputField.text), min, max).ToString();
        }
    }
}
