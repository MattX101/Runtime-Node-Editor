using RuntimeNodeEditor.UI.Canvas.Node.UI;
using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Pointer
{
    internal static partial class UIPointers
    {
        internal static TMP_InputField AddInputField(RuntimeNodeEditor.Node.Node.Node node, Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            float posX = UISettings.NodeWidth / 2;
            posX += UISettings.PointerSize / 4;
            posX = shorten ? posX - UISettings.PointerSize / 4 : posX;
            posX = !pointerIsInput ? -posX : posX;
            
            float posY = layer * -(UISettings.InputFieldHeight + UISettings.PointerPadding);

            TMP_InputField inputField = AddInputFieldOfType(node, contentType, parent, interactable, shorten);
            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }

        internal static TMP_InputField AddHalfInputField(RuntimeNodeEditor.Node.Node.Node node, Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            float posX = UISettings.NodeWidth / 4;
            posX += UISettings.PointerSize / 4;
            posX = !pointerIsInput ? -posX : posX;
            float posY = layer * -(UISettings.InputFieldHeight + UISettings.PointerPadding);

            TMP_InputField inputField = AddInputFieldOfType(node, contentType, parent, interactable, shorten, true);
            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }

        private static TMP_InputField AddInputFieldOfType(RuntimeNodeEditor.Node.Node.Node node, TMP_InputField.ContentType contentType, Transform parent, bool interactable, bool shorten, bool halfSize = false)
        {
            TMP_InputField inputField = null;

            if (contentType == TMP_InputField.ContentType.IntegerNumber)
            {
                inputField = UIIntInputField.Create(parent, interactable, shorten, halfSize);
                UIIntInputField.AddOnValueChange(inputField, node);
            }
            else if (contentType == TMP_InputField.ContentType.DecimalNumber)
            {
                inputField = UIFloatInputField.Create(parent, interactable, shorten, halfSize);
                UIFloatInputField.AddOnValueChange(inputField, node);
            }
            else
            {
                inputField = UIInputField.Create(parent, interactable, shorten, halfSize);
                UIInputField.AddOnValueChange(inputField, node);
            }

            return inputField;
        }
    }
}
