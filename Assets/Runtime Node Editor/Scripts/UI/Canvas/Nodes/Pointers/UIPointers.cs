using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.UI.Elements;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Pointer
{
    internal class UIPointers
    {
        private readonly RuntimeNodeEditor.Nodes.Node.Node _node;

        public UIPointers(RuntimeNodeEditor.Nodes.Node.Node node)
        {
            _node = node;
        }

        public GameObject CreatePointer(string name, GameObject parent, ValueType valueType, int i, bool createText, bool pointerIsInput)
        {
            GameObject uiElement = AddPointer(name, parent, valueType, i, createText, pointerIsInput);

            return uiElement;
        }

        private GameObject AddPointer(string name, GameObject parent, ValueType valueType, int i, bool createText, bool pointerIsInput)
        {
            GameObject uiElement = UIElement.Create(
                parent.transform,
                name,
                new Vector2(UISettings.PointerSize, UISettings.PointerSize),
                CalcualtePosition(
                    parent.GetComponent<RectTransform>(),
                    pointerIsInput, 
                    i));

            AddImage(uiElement, valueType);

            if (createText)
                AddText(uiElement, name, pointerIsInput);

            AddCollider(uiElement);

            return uiElement;
        }

        private Vector3 CalcualtePosition(RectTransform rect, bool isInput, int i)
        {
            float posX = rect.sizeDelta.x + UISettings.BorderSize * 2;
            posX = isInput ? -posX : posX;
            posX /= 2;

            float posY = (rect.sizeDelta.y - UISettings.PointerSize) / 2;
            posY -= i * (UISettings.PointerSize + UISettings.PointerPadding);

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

        public TMP_InputField AddInputField(Transform parent, TMP_InputField.ContentType contentType, int i, bool pointerIsInput, bool interactable)
        {
            TMP_InputField inputField = UIInputField.Create(parent, contentType, interactable);
            UIInputField.AddOnValueChange(inputField, _node);

            float posX = (UISettings.NodeWidth + UISettings.PointerSize) / 2;
            posX -= UISettings.BorderSize;
            posX = !pointerIsInput ? -posX : posX;
            float posY = i * -UISettings.InputFieldHeight;

            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }

        public BooleanButton AddBooleanPreview(Transform parent, bool pointerIsInput)
        {
            BooleanButton button = UIBooleanPreview.Create(parent, !pointerIsInput);
            UIBooleanPreview.AddOnValueChange(button.Button, _node);

            float posX = UISettings.PointerSize * 1.5f;
            posX = pointerIsInput ? posX : -posX;
            button.Button.gameObject.transform.localPosition = new Vector3(posX, 0, -1);

            return button;
        }

        public Slider AddSlider(Transform parent, bool pointerIsInput)
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
