using RuntimeNodeEditor.Node.Component;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIBooleanPreview
    {
        public static BooleanButton Create(Transform parent, bool interactable)
        {
            GameObject root = UIElement.Create(parent, "Boolean Preview", Vector2.one * 30, Vector3.zero);

            RawImage image = UIImage.Create(root, Color.red);

            Button button = root.AddComponent<Button>();
            button.transition = Selectable.Transition.None;
            button.onClick.AddListener(() => Toggle(image, button));
            button.interactable = interactable;
            if (!button.interactable) 
                image.color *= 0.75f;

            return new BooleanButton(button, image);
        }

        private static void Toggle(RawImage image, Button button)
        {
            image.color = 
                image.color.Equals(Color.red) ? 
                Color.green : 
                Color.red;
            
            if (!button.interactable) 
                image.color *= 0.75f;
        }

        public static void AddOnValueChange(Button button, RuntimeNodeEditor.Node.Node node)
        {
            button.onClick.AddListener(
                delegate
                {
                    node.MoveUp();
                });
        }
    }
}
