using RuntimeNodeEditor.Node.UIFunctions.Component;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static class UIBooleanPreview
    {
        public static BooleanButton Create(Transform parent, bool interactable = false)
        {
            GameObject RootObject = UIElement.Create(parent, "Boolean Preview", Vector2.one * 30, Vector3.zero);

            return new BooleanButton(
                RootObject, 
                UIImage.Create(RootObject, Color.red), 
                interactable);
        }

        public static void AddOnValueChange(Button button, RuntimeNodeEditor.Node.Node node)
        {
            button.onClick.AddListener(
                delegate
                {
                    node.OnValueChangeReset();
                });
        }
    }
}
