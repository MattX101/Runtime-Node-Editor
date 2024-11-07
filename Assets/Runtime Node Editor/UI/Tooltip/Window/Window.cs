using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Tooltip.Window
{
    public class Window : MonoBehaviour
    {
        [SerializeField] 
        protected GameObject WindowObject;
        
        public void Create()
        {
            if (GlobalData.NodesCanvasIsActive || GlobalData.WindowSpawnParent.childCount != 0)
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
            {
                Instantiate(WindowObject, GlobalData.WindowSpawnParent);
            }
            else
            {
                Destroy(gameObject);
            }

            GlobalData.WindowOpened = openWindow;

            Toggle();
        }

        private void Toggle()
        {
            LinkToTooltip.TooltipManager.ToggleButtons(!GlobalData.WindowOpened);
            GlobalData.NodeUIPanel.SetActive(GlobalData.WindowOpened);
        }
    }
}
