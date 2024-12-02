using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UIDropdown : MonoBehaviour
    {
        [SerializeField]
        private byte _startValue = 0;

        private void Awake()
        {
            if (TryGetComponent(out TMP_Dropdown dropdown))
            {
                dropdown.value = _startValue;
            }
            else
            {
                Debug.LogError("Dropdown component not found!");
                return;
            }
        }
    }
}
