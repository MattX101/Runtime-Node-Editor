using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public class UIInputField : MonoBehaviour
    {
        [SerializeField]
        protected TMP_InputField _inputField;

        [SerializeField]
        protected bool _active = false;

        private void Awake()
        {
            _inputField.interactable = _active;
        }

        public void Enable()
        {
            if (!_active)
                return;

            _inputField.interactable = true;
        }

        public void Disable()
        {
            if (!_active)
                return;

            _inputField.interactable = false;
        }
    }
}
