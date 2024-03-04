using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Elements;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Pointer
{
    public class UIPointers
    {
        private List<GameObject> _inputs = new List<GameObject>();
        private List<GameObject> _outputs = new List<GameObject>();

        public GameObject CreateInputPointer(string name, GameObject parent, ValueType valueType, int i)
        {
            RectTransform rect = parent.GetComponent<RectTransform>();

            Vector2 size = new Vector2(UISettings.pointerSize, UISettings.pointerSize);
            float posY = (rect.sizeDelta.y / 2) - (i * UISettings.pointerSize) - (UISettings.pointerSize / 2) - (i * (UISettings.pointerSize / 2)) - (UISettings.pointerSize / 2);
            Vector3 pos = new Vector3(-(rect.sizeDelta.x / 2), posY, 0.0f);

            string objectName = name;
            GameObject uiElement = UIElement.CreateUIElement(parent.transform, objectName, size, pos);

            UIImage.CreateRawImage(uiElement, PickPointerColor(valueType));
            UIImage.AssignTexture(uiElement);
            TextMeshPro text = UIText.CreateText(uiElement.transform, objectName + " Text", new Vector2(60.0f, 20.0f), new Vector3(50.0f, 0.0f, -1.0f), objectName);
            text.alignment = TextAlignmentOptions.Left;

            RectTransform pointerRect = uiElement.GetComponent<RectTransform>();
            CircleCollider2D circleCollider2D = uiElement.AddComponent<CircleCollider2D>();
            circleCollider2D.radius = pointerRect.rect.width / 2;

            _inputs.Add(uiElement);

            return uiElement;
        }

        public GameObject CreateOutputPointer(string name, GameObject parent, ValueType valueType, int i)
        {
            RectTransform rect = parent.GetComponent<RectTransform>();

            Vector2 size = new Vector2(UISettings.pointerSize, UISettings.pointerSize);
            float posY = (rect.sizeDelta.y / 2) - (i * UISettings.pointerSize) - (UISettings.pointerSize / 2) - (i * (UISettings.pointerSize / 2)) - (UISettings.pointerSize / 2);
            Vector3 pos = new Vector3(rect.sizeDelta.x / 2, posY, 0.0f);

            string objectName = name;
            GameObject uiElement = UIElement.CreateUIElement(parent.transform, objectName, size, pos);

            UIImage.CreateRawImage(uiElement, PickPointerColor(valueType));
            UIImage.AssignTexture(uiElement);
            TextMeshPro text = UIText.CreateText(uiElement.transform, objectName + " Text", new Vector2(60.0f, 20.0f), new Vector3(-50.0f, 0.0f, -1.0f), objectName);
            text.alignment = TextAlignmentOptions.Right;

            RectTransform pointerRect = uiElement.GetComponent<RectTransform>();
            CircleCollider2D circleCollider2D = uiElement.AddComponent<CircleCollider2D>();
            circleCollider2D.radius = pointerRect.rect.width / 2;

            _outputs.Add(uiElement);

            return uiElement;
        }

        public void UpdateUIPointers(RectTransform updatedRect, bool isInput)
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
        }

        private Color PickPointerColor(ValueType valueType)
        {
            return PointerColor.PickColor(valueType);
        }
    }
}
