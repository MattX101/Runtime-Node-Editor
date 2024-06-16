using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Header
{
    internal class Tab : MonoBehaviour
    {
        [SerializeField]
        private GameObject _tab;

        private TabsManager _tabsManagers;

        private void Awake()
        {
            _tabsManagers = GetComponentInParent<TabsManager>();
        }

        public void Show()
        {
            if (UIData.windowOpened)
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
            _tab.SetActive(toggle);
            UIData.tabOpened = toggle;
        }
    }
}
