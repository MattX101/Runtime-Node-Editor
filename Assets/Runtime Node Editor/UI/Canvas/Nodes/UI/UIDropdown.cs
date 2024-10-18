using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static class UIDropdown
    {
        public static RuntimeNodeEditor.Node.UIFunctions.Component.Dropdown Create(GameObject root, RuntimeNodeEditor.Node.Node node, string[] elements, string defualt)
        {
            float width = UISettings.NodeWidth * 0.8f - (UISettings.BorderSize * 2);
            float height = UISettings.PointerSize * elements.Length + UISettings.BorderSize;

            RuntimeNodeEditor.Node.UIFunctions.Component.Dropdown dropdown = new RuntimeNodeEditor.Node.UIFunctions.Component.Dropdown();

            // Root
            RawImage rootImage = root.AddComponent<RawImage>();
            rootImage.color = Color.white;

            Button button = root.AddComponent<Button>();
            button.targetGraphic = rootImage;

            // Title
            dropdown.Text = UIElement.Create(root.transform, "Label", new Vector2(width, UISettings.PointerSize), new Vector3(0, 0, -1)).AddComponent<TextMeshPro>();
            dropdown.Text.text = defualt;
            dropdown.Text.color = Color.black;
            dropdown.Text.enableAutoSizing = true;
            dropdown.Text.fontSizeMin = 18;
            dropdown.Text.fontSizeMax = 300;
            dropdown.Text.fontStyle = FontStyles.Bold;
            dropdown.Text.alignment = TextAlignmentOptions.Center;

            // Panel
            GameObject panel = UIElement.Create(root.transform, "Panel", Vector2.one, new Vector3(0, -UISettings.PointerSize / 2, 0));

            // Background
            GameObject background = UIElement.Create(panel.transform, "Background", new Vector2(width, height), new Vector3(0, -height / 2, 0));
            background.AddComponent<RawImage>().color = new Color(0.8f, 0.8f, 0.8f);

            // Toggles
            float halfSize = UISettings.PointerSize / 2;
            for (int i = 0; i < elements.Length; i++)
                AddOption(
                    panel,
                    dropdown,
                    elements[i],
                    (i * -UISettings.PointerSize) - halfSize,
                    width,
                    i,
                    node);

            button.onClick.AddListener(
                delegate
                {
                    panel.SetActive(!panel.activeSelf);
                });

            panel.SetActive(false);

            return dropdown;
        }

        private static void AddOption(GameObject parent, RuntimeNodeEditor.Node.UIFunctions.Component.Dropdown dropdown, string text, float posY, float width, int i, RuntimeNodeEditor.Node.Node node)
        {
            // Toggle
            GameObject optionObject = UIElement.Create(parent.transform, "Option - " + text, new Vector2(width, UISettings.PointerSize), new Vector3(0, posY, 0));
            Button button = optionObject.AddComponent<Button>();

            // Background
            GameObject background = UIElement.Create(optionObject.transform, "Bckground", new Vector2(width - (UISettings.BorderSize * 2), UISettings.PointerSize), Vector3.zero);
            background.AddComponent<CanvasRenderer>();

            RawImage backgroundImage = background.AddComponent<RawImage>();
            backgroundImage.color = new Color(0.9f, 0.9f, 0.9f);
            button.targetGraphic = backgroundImage;

            // Text
            TextMeshPro tmpText = UIElement.Create(optionObject.transform, "Text", new Vector2(width, UISettings.PointerSize), new Vector3(0, 0, -1)).AddComponent<TextMeshPro>();
            tmpText.text = text;
            tmpText.color = Color.black;
            tmpText.enableAutoSizing = true;
            tmpText.fontSizeMin = 18;
            tmpText.fontSizeMax = 300;
            tmpText.fontStyle = FontStyles.Bold;
            tmpText.alignment = TextAlignmentOptions.Center;

            button.onClick.AddListener(
                delegate
                {
                    parent.SetActive(false);
                    dropdown.Text.text = text;
                    dropdown.Context = i;
                    node.MoveUp();
                });
        }
    }
}