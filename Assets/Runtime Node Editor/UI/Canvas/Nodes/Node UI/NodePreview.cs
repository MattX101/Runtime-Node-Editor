using RuntimeNodeEditor.Node.UIFunctions.Component;
using RuntimeNodeEditor.UI.Canvas.Node.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public partial class NodeUI
    {
        protected ImagePreview ImagePreview;

        protected bool TogglePreviewImage = false;

        private void AddPreviewImage()
        {
            if (!TogglePreviewImage)
                return;

            float size = UISettings.PreviewSize - UISettings.PreviewImageMargin;

            Vector2 previewImageSize = new Vector2(size, size);
            float posY = (_rootRect.sizeDelta.y - size - UISettings.PreviewImageMargin) / 2 - UISettings.HeaderHeight - _bodyHeight;
            Vector3 previewImagePos = new Vector3(0.0f, posY, 0.0f);

            GameObject previewImageObject = UIElement.Create(
                RootObject.transform,
                "Preview",
                previewImageSize,
                previewImagePos);

            ImagePreview = new ImagePreview(UIImage.Create(previewImageObject, Color.black));
        }

        protected void PreviewColor(Slider r, Slider g, Slider b)
        {
            if (!TogglePreviewImage)
                return;

            if (ImagePreview == null)
            {
                AddPreviewImage();
            }

            ImagePreview.SetSliderInput(r, g, b);
        }
    }
}