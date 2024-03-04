using RuntimeNodeEditor.UI.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Interface
{
    public class InterfaceUIManager : MonoBehaviour
    {
        private TabsManager[] _tabsManagers;

        [SerializeField] private Transform windowSpawnParent;

        private Button[] buttons;

        void Awake()
        {
            UISettings.windowSpawnParent = windowSpawnParent;

            _tabsManagers = GetComponentsInChildren<TabsManager>();

            UIData.interfaceUIManager = this;

            buttons = FindObjectsOfType<Button>();
        }

        public void HideTabs()
        {
            foreach (TabsManager tabManager in _tabsManagers)
                tabManager.HideTabs();
        }

        public void ToggleButtons(bool active)
        {
            foreach (Button button in buttons)
                button.enabled = active;
        }
    }
}
