using RuntimeNodeEditor.UI.Elements;
using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Pointer
{
    internal partial class UIPointers
    {
        internal TMP_InputField AddInputField(Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            float posX = UISettings.NodeWidth / 2;
            posX += UISettings.PointerSize / 4;
            posX = shorten ? posX - UISettings.PointerSize / 4 : posX;
            posX = !pointerIsInput ? -posX : posX;
            
            float posY = layer * -(UISettings.InputFieldHeight + UISettings.PointerPadding);

            TMP_InputField inputField = AddInputFieldOfType(contentType, parent, interactable, shorten);
            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }

        internal TMP_InputField AddHalfInputField(Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            float posX = UISettings.NodeWidth / 4;
            posX += UISettings.PointerSize / 4;
            posX = !pointerIsInput ? -posX : posX;
            float posY = layer * -(UISettings.InputFieldHeight + UISettings.PointerPadding);

            TMP_InputField inputField = AddInputFieldOfType(contentType, parent, interactable, shorten, true);
            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }

        private TMP_InputField AddInputFieldOfType(TMP_InputField.ContentType contentType, Transform parent, bool interactable, bool shorten, bool halfSize = false)
        {
            TMP_InputField inputField = null;

            if (contentType == TMP_InputField.ContentType.IntegerNumber)
            {
                inputField = UIIntInputField.Create(parent, interactable, shorten, halfSize);
                UIIntInputField.AddOnValueChange(inputField, _node);
            }
            else if (contentType == TMP_InputField.ContentType.DecimalNumber)
            {
                inputField = UIFloatInputField.Create(parent, interactable, shorten, halfSize);
                UIFloatInputField.AddOnValueChange(inputField, _node);
            }
            else
            {
                inputField = UIInputField.Create(parent, interactable, shorten, halfSize);
                UIInputField.AddOnValueChange(inputField, _node);
            }

            return inputField;
        }
    }
}
