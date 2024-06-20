using RuntimeNodeEditor.Functions.UI.Component;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIBooleanPreview
    {
        public static BooleanButton Create(Transform parent, bool interactable)
        {
            GameObject root = UIElement.Create(parent, "Boolean Preview", Vector2.one * 30, Vector3.zero);
            BooleanButton booleanButton = new BooleanButton();

            RawImage image = UIImage.Create(root, Color.red);
            booleanButton.image = image;

            Button button = root.AddComponent<Button>();
            booleanButton.button = button;

            button.transition = Selectable.Transition.None;
            button.onClick.AddListener(() => booleanButton.Toggle());
            button.interactable = interactable;
            if (!button.interactable) 
                image.color *= 0.75f;

            return booleanButton;
        }

        public static void AddOnValueChange(Button button, RuntimeNodeEditor.Nodes.Node.Node node)
        {
            button.onClick.AddListener(
                delegate
                {
                    node.MoveUp();
                });
        }
    }
}
