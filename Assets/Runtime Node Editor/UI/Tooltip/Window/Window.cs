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
            if (CanvasData.NodesCanvasIsActive || UISettings.WindowSpawnParent.childCount != 0)
                return;

            Manage(true);
        }

        public void Close()
        {
            Manage(false);
        }

        private void Manage(bool openWindow)
        {
            if (openWindow) 
                Instantiate(window, UISettings.WindowSpawnParent);
            else 
                Destroy(gameObject);

            Toggle();

            UIData.WindowOpened = openWindow;
        }

        private void Toggle()
        {
            LinkToTooltip.TooltipManager.ToggleButtons(!UIData.WindowOpened);
            UIData.NodeUIPanel.SetActive(UIData.WindowOpened);
        }
    }
}
