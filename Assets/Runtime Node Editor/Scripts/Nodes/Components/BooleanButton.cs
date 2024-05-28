using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Node.Component
{
    public class BooleanButton : MonoBehaviour
    {
        [NonSerialized]
        public Button button;

        [NonSerialized]
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