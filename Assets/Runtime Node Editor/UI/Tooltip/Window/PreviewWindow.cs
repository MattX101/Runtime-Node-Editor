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
            if (GlobalData.NodesCanvasIsActive)
                return;
            
            if (GlobalData.WindowOpened)
                return;

            WindowObject.SetActive(!WindowObject.activeSelf);

            _togglePreviewIcon.color =
                WindowObject.activeSelf ?
                Color.white :
                InActiveIconColor();
        }

        public void Hide()
        {
            WindowObject.SetActive(false);

            _togglePreviewIcon.color = InActiveIconColor();
        }

        private Color InActiveIconColor()
        {
            return new Color(0.75f, 0.75f, 0.75f);
        }
    }
}
