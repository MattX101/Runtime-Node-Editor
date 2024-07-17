using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIImage
    {
        private static bool _previewImageIsActive = true;

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

        public static void Toggle(bool isToggled, GameObject previewImage)
        {
            if (_previewImageIsActive != isToggled)
                return;
            
            previewImage.SetActive(!isToggled);
            _previewImageIsActive = !isToggled;
        }
    }
}
