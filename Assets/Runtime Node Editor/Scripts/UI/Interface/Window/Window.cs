using RuntimeNodeEditor.UI.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Interface
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] protected GameObject window;

        public void Create()
        {
            if (UISettings.windowSpawnParent.childCount == 0)
            {
                UIData.windowOpened = true;
                Instantiate(window, UISettings.windowSpawnParent);

                Toggle();
            }
        }

        public void Close()
        {
            UIData.windowOpened = false;
            Destroy(this.gameObject);

            Toggle();
        }

        private void Toggle()
        {
            ToggleButtons();
            ToggleNodePanel();
        }

        private void ToggleButtons()
        {
            UIData.interfaceUIManager.ToggleButtons(!UIData.windowOpened);
        }

        private void ToggleNodePanel()
        {
            UIData.nodePanel.SetActive(UIData.windowOpened);
        }
    }
}
