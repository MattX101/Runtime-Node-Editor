using UnityEngine.UI;
using UnityEngine;
using TMPro;
using RuntimeNodeEditor.Data;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static class UIDropdown
    {
        public static RuntimeNodeEditor.Node.UIFunctions.Component.Dropdown Create(GameObject RootObject, RuntimeNodeEditor.Node.Node node, string[] Elements, string defualt)
        {
            float width = GlobalData.NodeWidth * 0.8f - (GlobalData.BorderSize * 2);
            float height = GlobalData.PointerSize * Elements.Length + GlobalData.BorderSize;

            RuntimeNodeEditor.Node.UIFunctions.Component.Dropdown dropdown = new RuntimeNodeEditor.Node.UIFunctions.Component.Dropdown();

            // Root
            RawImage rootImage = RootObject.AddComponent<RawImage>();
            rootImage.color = Color.white;

            Button button = RootObject.AddComponent<Button>();
            button.targetGraphic = rootImage;

            // Title
            dropdown.CreateText(UIElement.Create(RootObject.transform, "Label", new Vector2(width, GlobalData.PointerSize), new Vector3(0, 0, -1)).AddComponent<TextMeshPro>());
            dropdown.Text.text = defualt;
            dropdown.Text.color = Color.black;
            dropdown.Text.enableAutoSizing = true;
            dropdown.Text.fontSizeMin = 18;
            dropdown.Text.fontSizeMax = 300;
            dropdown.Text.fontStyle = FontStyles.Bold;
            dropdown.Text.alignment = TextAlignmentOptions.Center;

            // Panel
            GameObject panel = UIElement.Create(RootObject.transform, "Panel", Vector2.one, new Vector3(0, -GlobalData.PointerSize / 2, 0));

            // Background
            GameObject background = UIElement.Create(panel.transform, "Background", new Vector2(width, height), new Vector3(0, -height / 2, 0));
            background.AddComponent<RawImage>().color = new Color(0.8f, 0.8f, 0.8f);

            // Toggles
            float halfSize = GlobalData.PointerSize / 2;
            for (int i = 0; i < Elements.Length; i++)
            {
                AddOption(
                    panel,
                    dropdown,
                    Elements[i],
                    (i * -GlobalData.PointerSize) - halfSize,
                    width,
                    i,
                    node);
            }

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
            GameObject optionObject = UIElement.Create(parent.transform, "Option - " + text, new Vector2(width, GlobalData.PointerSize), new Vector3(0, posY, 0));
            Button button = optionObject.AddComponent<Button>();

            // Background
            GameObject background = UIElement.Create(optionObject.transform, "Bckground", new Vector2(width - (GlobalData.BorderSize * 2), GlobalData.PointerSize), Vector3.zero);
            background.AddComponent<CanvasRenderer>();

            RawImage backgroundImage = background.AddComponent<RawImage>();
            backgroundImage.color = new Color(0.9f, 0.9f, 0.9f);
            button.targetGraphic = backgroundImage;

            // Text
            TextMeshPro tmpText = UIElement.Create(optionObject.transform, "Text", new Vector2(width, GlobalData.PointerSize), new Vector3(0, 0, -1)).AddComponent<TextMeshPro>();
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
                    dropdown.SetContext(i);
                    node.MoveUp();
                });
        }
    }
}