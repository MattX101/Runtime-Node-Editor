using RuntimeNodeEditor.UI.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Interface
{
    public class PreviewWindow : Window
    {
        [SerializeField] private Image _togglePreviewIcon;

        private void Awake()
        {
            Hide();
        }

        public void Toggle()
        {
            if (!UIData.windowOpened)
            {
                window.SetActive(!window.activeSelf);

                _togglePreviewIcon.color =
                    window.activeSelf ?
                    Color.white :
                    new Color(0.75f, 0.75f, 0.75f);
            }
        }

        public void Hide()
        {
            window.SetActive(false);

            _togglePreviewIcon.color = new Color(0.75f, 0.75f, 0.75f);
        }
    }
}
