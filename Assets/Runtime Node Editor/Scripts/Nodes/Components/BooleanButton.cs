using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Node.Component
{
    public class BooleanButton
    {
        public Button button;
        public RawImage image;

        public bool Toggled
        {
            get
            {
                return 
                    image.color == Color.green ? 
                    true : 
                    false;
            }
        }

        public BooleanButton(Button button, RawImage image)
        {
            this.button = button;
            this.image = image;
        }

        public void Toggle(bool toggle)
        {
            image.color = toggle ? Color.green : Color.red;
            if (!button.interactable)
                image.color *= 0.75f;
        }
    }
}