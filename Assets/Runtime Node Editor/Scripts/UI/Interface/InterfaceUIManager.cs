using RuntimeNodeEditor.UI.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Interface
{
    public class InterfaceUIManager : MonoBehaviour
    {
        private TabsManager[] _tabsManagers;

        [SerializeField] private Transform _windowSpawnParent;
        [SerializeField] private GameObject _nodePanel;

        private Button[] _buttons;

        void Awake()
        {
            UISettings.windowSpawnParent = _windowSpawnParent;

            _tabsManagers = GetComponentsInChildren<TabsManager>();

            UIData.interfaceUIManager = this;
            UIData.nodePanel = _nodePanel;

            _buttons = FindObjectsOfType<Button>();
        }

        public void HideTabs()
        {
            foreach (TabsManager tabManager in _tabsManagers)
                tabManager.HideTabs();
        }

        public void ToggleButtons(bool active)
        {
            foreach (Button button in _buttons)
                button.enabled = active;
        }
    }
}
