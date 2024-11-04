using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Node.UIFunctions.Component
{
    public class BooleanButton
    {
        public Button Button
        {
            get;
        }

        private readonly RawImage _image;

        public bool Toggled
        {
            get;
            private set;
        }

        public BooleanButton(GameObject RootObject, RawImage image, bool interactable)
        {
            Button = RootObject.AddComponent<Button>();
            _image = image;

            Button.transition = Selectable.Transition.ColorTint;
            
            ColorBlock colors = Button.colors;
            colors.normalColor = Color.white * 0.9f;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white * 0.9f;
            colors.selectedColor = Color.white * 0.9f;
            colors.disabledColor = Color.white * 0.75f;
            colors.fadeDuration = 0.0f;
            Button.colors = colors;

            Button.onClick.AddListener(() => Toggle());
            Button.interactable = interactable;

            if (!Button.interactable)
                _image.color *= 0.75f;
        }

        public void Toggle()
        {
            Toggle(!Toggled);
        }

        internal void Toggle(bool toggle)
        {
            _image.color = toggle ? Color.green : Color.red;
            Toggled = toggle;

            if (!Button.interactable)
                _image.color *= 0.75f;
        }
    }
}