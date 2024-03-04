using UnityEngine;
using RuntimeNodeEditor.UI.Data;

namespace RuntimeNodeEditor.UI.Interface
{
    public class Tab : MonoBehaviour
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
            if (!UIData.windowOpened)
            {
                _tabsManagers.HideTabs();

                _tab.SetActive(true);
                UIData.tabOpened = true;
            }
        }

        public void Hide()
        {
            _tab.SetActive(false);
            UIData.tabOpened = false;
        }
    }
}
