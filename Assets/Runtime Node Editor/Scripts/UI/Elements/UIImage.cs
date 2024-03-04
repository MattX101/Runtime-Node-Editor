using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Elements
{
    public static class UIImage
    {
        private static bool _previewImageIsActive = true;

        public static RawImage CreateRawImage(GameObject uiElement, Color color)
        {
            RawImage rawImage = uiElement.AddComponent<RawImage>();
            rawImage.color = color;

            return rawImage;
        }

        public static void AssignTexture(GameObject uiElement)
        {
            uiElement.TryGetComponent<RawImage>(out RawImage rawImage);
            if (rawImage != null) rawImage.texture = UISettings.pointerTexture;
        }

        public static void TogglePreviewImage(bool isToggled, GameObject previewImage)
        {
            if (_previewImageIsActive == isToggled)
            {
                previewImage.SetActive(!isToggled);
                _previewImageIsActive = !isToggled;
            }
        }
    }
}
