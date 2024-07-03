using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.UI.Elements;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Pointer
{
    internal class UIPointers
    {
        private readonly RuntimeNodeEditor.Nodes.Node.Node _node;

        public UIPointers(RuntimeNodeEditor.Nodes.Node.Node node)
        {
            _node = node;
        }

        public GameObject CreatePointer(string name, GameObject parent, ValueType valueType, int layer, bool pointerIsInput = false, bool createText = false)
        {
            GameObject uiElement = UIElement.Create(
                parent.transform,
                name,
                new Vector2(UISettings.PointerSize, UISettings.PointerSize),
                CalcualtePosition(
                    parent.GetComponent<RectTransform>(),
                    pointerIsInput,
                    layer));

            AddImage(uiElement, valueType);

            if (createText)
                AddText(uiElement, name, pointerIsInput);

            AddCollider(uiElement);

            return uiElement;
        }

        private Vector3 CalcualtePosition(RectTransform rect, bool isInput, int layer)
        {
            float posX = rect.sizeDelta.x + UISettings.BorderSize * 2;
            posX = isInput ? -posX : posX;
            posX /= 2;

            float posY = (rect.sizeDelta.y - UISettings.PointerSize) / 2;
            posY -= layer * (UISettings.PointerSize + UISettings.PointerPadding);

            return new Vector3(posX, posY, 0.0f);
        }

        private void AddImage(GameObject uiElement, ValueType valueType)
        {
            UIImage.Create(uiElement, PickPointerColor(valueType));
            UIImage.AssignTexture(uiElement);
        }

        private void AddText(GameObject uiElement, string name, bool isInput)
        {
            float x = 50;
            x = isInput ? x : -x;

            TextMeshPro text = UIText.CreateText(
                uiElement.transform, 
                "Text", 
                new Vector2(60, 20), 
                new Vector3(x, 0, -1), 
                name);
            
            UIText.SetFontAlignment(
                text, 
                isInput ? TextAlignmentOptions.Left : TextAlignmentOptions.Right);
        }

        private void AddCollider(GameObject uiElement)
        {
            RectTransform pointerRect = uiElement.GetComponent<RectTransform>();
            CircleCollider2D circleCollider2D = uiElement.AddComponent<CircleCollider2D>();
            circleCollider2D.radius = pointerRect.rect.width / 2;
        }

        public TMP_InputField AddInputField(Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, int layer = 0)
        {
            TMP_InputField inputField = UIInputField.Create(parent, contentType, interactable);
            UIInputField.AddOnValueChange(inputField, _node);

            float posX = (UISettings.NodeWidth + UISettings.PointerSize) / 2;
            posX -= UISettings.BorderSize;
            posX = !pointerIsInput ? -posX : posX;
            float posY = layer * -UISettings.InputFieldHeight;

            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }
        public TMP_InputField AddHalfInputField(Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, int layer = 0)
        {
            TMP_InputField inputField = UIInputField.Create(parent, contentType, interactable, true);
            UIInputField.AddOnValueChange(inputField, _node);

            float posX = ((UISettings.NodeWidth / 2) + UISettings.PointerSize) / 2;
            posX -= UISettings.BorderSize;
            posX = !pointerIsInput ? -posX : posX;
            float posY = layer * -UISettings.InputFieldHeight;

            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }

        public BooleanButton AddBooleanPreview(Transform parent, bool pointerIsInput = false, bool interactable = false)
        {
            BooleanButton button = UIBooleanPreview.Create(parent, interactable);
            UIBooleanPreview.AddOnValueChange(button.Button, _node);

            float posX = UISettings.PointerSize * 1.5f;
            posX = pointerIsInput ? posX : -posX;
            button.Button.gameObject.transform.localPosition = new Vector3(posX, 0, -1);

            return button;
        }

        public Slider AddSlider(Transform parent, bool pointerIsInput = false)
        {
            GameObject sliderObject = UISlider.Create(parent);
            Slider slider = UISlider.CreateSlider(sliderObject.transform);

            float posX = sliderObject.transform.localPosition.x;
            if (pointerIsInput)
            {
                posX += UISettings.NodeWidth;
                posX += UISettings.SliderTextFieldWidth;
                posX += UISettings.BorderSize;
                posX += UISettings.PointerSize * 1.5f;
            }
            sliderObject.transform.localPosition = new Vector3(posX, 0, -1);

            return slider;
        }

        private Color PickPointerColor(ValueType valueType)
        {
            return PointerColor.PickColor(valueType);
        }
    }
}
