using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Component
{
    public class BooleanButton
    {
        public Button Button;
        private RawImage _image;

        public bool Toggled;

        public BooleanButton(GameObject root, RawImage image, bool interactable)
        {
            Button = root.AddComponent<Button>();
            _image = image;

            Button.transition = Selectable.Transition.ColorTint;
            
            ColorBlock colors = Button.colors;
            colors.normalColor = Color.white * 0.9f;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white * 0.9f;
            colors.disabledColor = Color.white * 0.75f;
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