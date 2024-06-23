using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Tooltip.Window
{
    internal class Window : MonoBehaviour
    {
        [SerializeField] 
        protected GameObject window;
        
        public void Create()
        {
            if (CanvasData.NodesCanvasIsActive)
                return;
            
            if (UISettings.WindowSpawnParent.childCount != 0)
                return;

            Manage(true);
        }

        public void Close()
        {
            Manage(false);
        }

        private void Manage(bool windowIsOpen)
        {
            UIData.WindowOpened = windowIsOpen;

            if (windowIsOpen) 
                Instantiate(window, UISettings.WindowSpawnParent);
            else 
                Destroy(gameObject);

            Toggle();
        }

        private void Toggle()
        {
            LinkToTooltip.TooltipManager.ToggleButtons(!UIData.WindowOpened);
            UIData.NodePanel.SetActive(UIData.WindowOpened);
        }
    }
}
