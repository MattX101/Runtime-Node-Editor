using RuntimeNodeEditor.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Tooltip.Window
{
    internal class PreviewWindow : Window
    {
        [SerializeField] 
        private Image _togglePreviewIcon;

        private void Awake()
        {
            Hide();
        }

        public void Toggle()
        {
            if (UIData.windowOpened)
                return;

            window.SetActive(!window.activeSelf);

            _togglePreviewIcon.color =
                window.activeSelf ?
                Color.white :
                InActiveIconColor();
        }

        public void Hide()
        {
            window.SetActive(false);

            _togglePreviewIcon.color = InActiveIconColor();
        }

        private Color InActiveIconColor()
        {
            return new Color(0.75f, 0.75f, 0.75f);
        }
    }
}
