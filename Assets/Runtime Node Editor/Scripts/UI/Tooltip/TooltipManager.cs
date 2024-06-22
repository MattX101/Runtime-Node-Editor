using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.UI.Tooltip.Tab;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Tooltip
{
    internal class TooltipManager : MonoBehaviour
    {
        private TabsManager[] _tabsManagers;

        [SerializeField] private Transform windowSpawnParent;
        [SerializeField] private GameObject nodePanel;

        private Button[] _buttons;

        private void Awake()
        {
            UISettings.WindowSpawnParent = windowSpawnParent;
            UIData.NodePanel = nodePanel;

            _tabsManagers = GetComponentsInChildren<TabsManager>();
            _buttons = FindObjectsOfType<Button>();

            LinkToTooltip.TooltipManager = this;
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
