using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Component
{
    public class BooleanButton
    {
        public Button button;
        public RawImage image;

        public bool Toggled = false;

        public void Toggle()
        {
            Toggle(!Toggled);
        }

        public void Toggle(bool toggle)
        {
            image.color = toggle ? Color.green : Color.red;
            Toggled = toggle;

            if (!button.interactable)
                image.color *= 0.75f;
        }
    }
}