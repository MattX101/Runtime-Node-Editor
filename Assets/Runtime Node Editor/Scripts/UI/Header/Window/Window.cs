using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Header
{
    public class Window : MonoBehaviour
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
                Destroy(this.gameObject);

            Toggle();
        }

        private void Toggle()
        {
            HeaderUIManagerLink.headerUIManager.ToggleButtons(!UIData.windowOpened);
            UIData.nodePanel.SetActive(UIData.windowOpened);
        }
    }
}
