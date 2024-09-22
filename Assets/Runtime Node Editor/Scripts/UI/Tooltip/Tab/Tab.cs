using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Tooltip.Tab
{
    internal class Tab : MonoBehaviour
    {
        [SerializeField]
        private GameObject tab;

        private TabsManager _tabsManagers;

        private void Awake()
        {
            _tabsManagers = GetComponentInParent<TabsManager>();
        }

        public void Show()
        {
            if (CanvasData.NodesCanvasIsActive || UIData.WindowOpened)
                return;

            _tabsManagers.HideTabs();

            Toggle(true);
        }

        public void Hide()
        {
            Toggle(false);
        }

        private void Toggle(bool toggle)
        {
            tab.SetActive(toggle);
            UIData.TabOpened = toggle;
        }
    }
}
