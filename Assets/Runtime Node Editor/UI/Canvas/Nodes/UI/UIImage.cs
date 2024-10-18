using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static class UIImage
    {
        public static RawImage Create(GameObject uiElement, Color color)
        {
            RawImage rawImage = uiElement.AddComponent<RawImage>();
            rawImage.color = color;

            return rawImage;
        }

        public static void AssignTexture(GameObject uiElement, Texture2D texture)
        {
            uiElement.TryGetComponent(out RawImage rawImage);

            if (!rawImage)
                return;
            
            rawImage.texture = texture;
        }
    }
}
