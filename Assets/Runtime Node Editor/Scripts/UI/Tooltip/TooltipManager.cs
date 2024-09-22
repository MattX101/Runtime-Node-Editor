using RuntimeNodeEditor.UI.Tooltip.Tab;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Tooltip
{
    internal class TooltipManager : MonoBehaviour
    {
        private TabsManager[] _tabsManagers;

        private Button[] _buttons;

        [Header("Auto Tooltip Scaling")]
        [SerializeField] private Camera _camera;
        [SerializeField] private CanvasScaler _scaler;

        private void Awake()
        {
            _tabsManagers = GetComponentsInChildren<TabsManager>();
            _buttons = FindObjectsOfType<Button>();

            LinkToTooltip.TooltipManager = this;
        }

        // TODO - Change from Update() to an OnValueChange method
        private void Update()
        {
            _scaler.matchWidthOrHeight = _camera.pixelWidth > _camera.pixelHeight ? 0 : 1;
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
