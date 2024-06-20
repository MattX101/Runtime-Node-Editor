using UnityEngine;

namespace RuntimeNodeEditor.UI.Tooltip.Tab
{
    internal class TabsManager : MonoBehaviour
    {
        private Tab[] _tabs;

        private void Start()
        {
            _tabs = GetComponentsInChildren<Tab>();
        }

        public void HideTabs()
        {
            foreach (Tab tab in _tabs)
                tab.Hide();
        }
    }
}
