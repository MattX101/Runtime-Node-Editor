using RuntimeNodeEditor.Functions.UI.Component;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal partial class NodeUI
    {
        protected TMP_InputField AddInputField(Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            return _uiPointers.AddInputField(
                parent,
                contentType,
                pointerIsInput,
                interactable,
                shorten,
                layer);
        }
        protected TMP_InputField AddHalfInputField(Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            return _uiPointers.AddHalfInputField(
                parent,
                contentType,
                pointerIsInput,
                interactable,
                shorten,
                layer);
        }

        protected BooleanButton AddBooleanPreview(Transform parent, bool pointerIsInput = false, bool interactable = false)
        {
            return _uiPointers.AddBooleanPreview(parent, pointerIsInput, interactable);
        }

        protected Slider AddSlider(Transform parent, bool pointerIsInput = false)
        {
            return _uiPointers.AddSlider(parent, pointerIsInput);
        }
    }
}
