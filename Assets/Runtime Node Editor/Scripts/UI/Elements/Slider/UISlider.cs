using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Elements
{
    public static partial class UISlider
    {
        public static GameObject Create(Transform root)
        {
            // Root
            GameObject rootObject = UIElement.Create(
                root,
                "Slider Element",
                Vector2.zero,
                new Vector3(
                    -UISettings.NodeWidth + UISettings.BorderSize, 
                    0, 
                    -1)
                );

            CreateBackground(rootObject.transform);

            return rootObject;
        }

        private static void CreateBackground(Transform parent)
        {
            // Background
            float scaleX = UISettings.NodeWidth;
            scaleX -= UISettings.PointerSize / 2;
            scaleX -= UISettings.BorderSize * 4;

            GameObject background = UIElement.Create(
                parent,
                "Background",
                new Vector2(scaleX, UISettings.PointerSize),
                new Vector3(scaleX / 2, 0, 0));

            RawImage backgroundImage = background.AddComponent<RawImage>();
            backgroundImage.color = Color.white * 0.75f;
        }
    }
}
