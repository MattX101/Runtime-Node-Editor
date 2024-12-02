using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public class UIBooleanButton : MonoBehaviour
    {
        [SerializeField]
        private Toggle _toggle;

        [SerializeField] 
        private bool _active = false;

        private void Awake()
        {
            _toggle.interactable = _active;
            SwitchColor();
        }

        public void OnToggle()
        {
            SwitchColor();
        }

        private void SwitchColor()
        {
            switch (_toggle.isOn)
            {
                case true:
                    _toggle.targetGraphic.color = Color.green;
                    break;
                case false:
                    _toggle.targetGraphic.color = Color.red;
                    break;
            }
        }

        public void Enable()
        {
            if (!_active)
                return;

            _toggle.interactable = true;
        }

        public void Disable()
        {
            if (!_active)
                return;

            _toggle.interactable = false;
        }
    }
}
