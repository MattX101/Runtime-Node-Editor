using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Elements;
using RuntimeNodeEditor.UI.Node;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Pointer
{
    public class UIPointers
    {
        private List<GameObject> _inputs = new List<GameObject>();
        private List<GameObject> _outputs = new List<GameObject>();

        public GameObject CreatePointer(string name, GameObject parent, ValueType valueType, int i, bool createText, bool pointerIsInput)
        {
            GameObject uiElement = AddPointer(name, parent, valueType, i, createText, pointerIsInput);
            
            if (pointerIsInput)
                _inputs.Add(uiElement);
            else
                _outputs.Add(uiElement);

            return uiElement;
        }

        private GameObject AddPointer(string name, GameObject parent, ValueType valueType, int i, bool createText, bool pointerIsInput)
        {
            GameObject uiElement = UIElement.CreateUIElement(
                parent.transform,
                name,
                new Vector2(UISettings.pointerSize, UISettings.pointerSize),
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

        /*public void UpdateUIPointers(RectTransform updatedRect, bool isInput)
        {
            int numOfPointers = isInput ? _inputs.Count : _outputs.Count;
            for (int i = 0; i < numOfPointers; i++)
            {
                float posX = isInput ? -(updatedRect.sizeDelta.x / 2) : updatedRect.sizeDelta.x / 2;
                float posY = (updatedRect.sizeDelta.y / 2) - (i * UISettings.pointerSize) - (UISettings.pointerSize / 2) - (i * (UISettings.pointerSize / 2)) - (UISettings.pointerSize / 2);

                Vector2 size = new Vector2(UISettings.pointerSize, UISettings.pointerSize);
                Vector3 pos = new Vector3(posX, posY, 0.0f);

                RectTransform pointerRectTransform = isInput ?
                    _inputs[i].GetComponent<RectTransform>() :
                    _outputs[i].GetComponent<RectTransform>();
                UIElement.UpdateUIElement(pointerRectTransform, size, pos);
            }
        }*/

        private Vector3 CalcualtePosition(RectTransform rect, bool isInput, int i)
        {
            float posX = rect.sizeDelta.x + UISettings.borderSize * 2;
            posX = isInput ? -posX : posX;
            posX /= 2;

            float posY = (rect.sizeDelta.y - UISettings.pointerSize) / 2;
            posY -= i * (UISettings.pointerSize + UISettings.pointerPadding);

            return new Vector3(posX, posY, 0.0f);
        }

        private void AddImage(GameObject uiElement, ValueType valueType)
        {
            UIImage.CreateRawImage(uiElement, PickPointerColor(valueType));
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
            
            UIText.SetFontAligment(
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
            TMP_InputField inputField = UIInputField.CreateInputField(parent, contentType, interactable);

            float posX = (UISettings.nodeWidth + UISettings.pointerSize) / 2;
            posX -= UISettings.borderSize;
            posX = !pointerIsInput ? -posX : posX;
            float posY = i * -UISettings.inputFieldHeight;

            inputField.gameObject.transform.localPosition = new Vector3(posX, posY, -1);

            return inputField;
        }

        public Button AddBooleanPreview(Transform parent, bool pointerIsInput)
        {
            Button button = UIBooleanPreview.CreateBooleanPreview(parent, !pointerIsInput);

            float posX = UISettings.pointerSize * 1.5f;
            posX = pointerIsInput ? posX : -posX;
            button.gameObject.transform.localPosition = new Vector3(posX, 0, -1);

            return button;
        }

        public Slider AddSlider(Transform parent, bool pointerIsInput)
        {
            GameObject sliderObject = UISlider.CreateElement(parent);
            Slider slider = UISlider.CreateSliderElement(sliderObject.transform);

            float posX = sliderObject.transform.localPosition.x;
            //incorrect
            if (pointerIsInput)
            {
                posX += UISettings.nodeWidth;
                posX += UISettings.sliderTextFieldWidth;
                posX += UISettings.borderSize;
                posX += UISettings.pointerSize * 1.5f;
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
