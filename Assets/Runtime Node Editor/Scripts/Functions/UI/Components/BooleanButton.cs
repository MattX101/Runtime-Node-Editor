using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Component
{
    public class BooleanButton
    {
        public Button Button;
        public RawImage Image;

        public bool Toggled;

        public void Toggle()
        {
            Toggle(!Toggled);
        }

        public void Toggle(bool toggle)
        {
            Image.color = toggle ? Color.green : Color.red;
            Toggled = toggle;

            if (!Button.interactable)
                Image.color *= 0.75f;
        }
    }
}