using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Tooltip.Window
{
    internal class Window : MonoBehaviour
    {
        [SerializeField] 
        private Transform _parent;

        [SerializeField] 
        protected GameObject window;
        
        public void Create()
        {
            if (UISettings.windowSpawnParent.childCount != 0)
                return;

            Manage(true);
        }

        public void Close()
        {
            Manage(false);
        }

        private void Manage(bool windowIsOpen)
        {
            UIData.windowOpened = windowIsOpen;

            if (windowIsOpen) 
                Instantiate(window, UISettings.windowSpawnParent);
            else 
                Destroy(gameObject);

            Toggle();
        }

        private void Toggle()
        {
            LinkToTooltip.tooltipManager.ToggleButtons(!UIData.windowOpened);
            UIData.nodePanel.SetActive(UIData.windowOpened);
        }
    }
}
