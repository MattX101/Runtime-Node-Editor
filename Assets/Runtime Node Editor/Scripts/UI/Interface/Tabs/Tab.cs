using UnityEngine;
using RuntimeNodeEditor.UI.Data;

namespace RuntimeNodeEditor.UI.Interface
{
    public class Tab : MonoBehaviour
    {
        [SerializeField]
        private GameObject _tab;

        [SerializeField]
        private TabsManager _tabsManagers;

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
