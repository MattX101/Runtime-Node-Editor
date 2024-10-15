using UnityEngine;
using System;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static class UIFloatInputField
    {
        public static TMP_InputField Create(Transform parent, bool interactable = true, bool shorten = false, bool halfSize = false)
        {
            // Input Field
            TMP_InputField inputField = UIInputField.AddInputField(parent, "Float Input Field", interactable, shorten, halfSize);
            inputField.contentType = TMP_InputField.ContentType.DecimalNumber;

            return inputField;
        }

        public static void AddOnValueChange(TMP_InputField inputField, RuntimeNodeEditor.Node.Node node)
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

        public static void AddValueRange(TMP_InputField inputField, float min, float max)
        {
            inputField.onValueChanged.AddListener(
                delegate
                {
                    ClampInput(inputField, min, max);
                });
        }

        private static void ClampInput(TMP_InputField inputField, float min, float max)
        {
            if (inputField.text.Length == 0)
                return;

            if (inputField.text.Length == 1 && inputField.text[0] == '-')
                return;

            float value = float.Parse(inputField.text);
            value = value < min ? min : value;
            value = value > max ? max : value;
        }
    }
}
