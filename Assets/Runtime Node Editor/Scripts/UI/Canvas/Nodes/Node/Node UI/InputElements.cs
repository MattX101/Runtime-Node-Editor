using RuntimeNodeEditor.UI.Canvas.Nodes.Pointer;
using RuntimeNodeEditor.Functions.UI.Component;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal partial class NodeUI
    {
        protected TMP_InputField AddInputField(RuntimeNodeEditor.Nodes.Node.Node node, Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            return UIPointers.AddInputField(
                node,
                parent,
                contentType,
                pointerIsInput,
                interactable,
                shorten,
                layer);
        }
        protected TMP_InputField AddHalfInputField(RuntimeNodeEditor.Nodes.Node.Node node, Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, bool shorten = false, int layer = 0)
        {
            return UIPointers.AddHalfInputField(
                node,
                parent,
                contentType,
                pointerIsInput,
                interactable,
                shorten,
                layer);
        }

        protected BooleanButton AddBooleanPreview(RuntimeNodeEditor.Nodes.Node.Node node, Transform parent, bool pointerIsInput = false, bool interactable = false)
        {
            return UIPointers.AddBooleanPreview(node, parent, pointerIsInput, interactable);
        }

        protected Slider AddLinearSlider(Transform parent, Color color, bool pointerIsInput = false)
        {
            return UIPointers.AddLinearSlider(parent, color, pointerIsInput);
        }

        protected Slider AddIntegerSlider(Transform parent, Color color, int max, bool pointerIsInput = false)
        {
            return AddIntegerSlider(parent, color, 0, max, pointerIsInput);
        }
        protected Slider AddIntegerSlider(Transform parent, Color color, int min, int max, bool pointerIsInput = false)
        {
            return UIPointers.AddIntegerSlider(parent, color, min, max, pointerIsInput);
        }
    }
}
