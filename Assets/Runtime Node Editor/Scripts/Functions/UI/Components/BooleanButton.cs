using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Component
{
    public class BooleanButton
    {
        public Button Button;
        private RawImage _image;

        public bool Toggled;

        public BooleanButton(Button button, RawImage image, bool interactable)
        {
            Button = button;
            _image = image;

            Button.transition = Selectable.Transition.None;
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