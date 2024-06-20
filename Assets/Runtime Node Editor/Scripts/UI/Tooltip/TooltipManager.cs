using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.UI.Tooltip.Tab;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Tooltip
{
    internal class TooltipManager : MonoBehaviour
    {
        private TabsManager[] _tabsManagers;

        [SerializeField] private Transform _windowSpawnParent;
        [SerializeField] private GameObject _nodePanel;

        private Button[] _buttons;

        private void Awake()
        {
            UISettings.windowSpawnParent = _windowSpawnParent;
            UIData.nodePanel = _nodePanel;

            _tabsManagers = GetComponentsInChildren<TabsManager>();
            _buttons = FindObjectsOfType<Button>();

            LinkToTooltip.tooltipManager = this;
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
