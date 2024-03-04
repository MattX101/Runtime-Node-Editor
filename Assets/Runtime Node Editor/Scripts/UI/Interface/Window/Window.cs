using RuntimeNodeEditor.UI.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Interface
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] protected GameObject window;

        public void Create()
        {
            if (UISettings.windowSpawnParent.childCount == 0)
            {
                UIData.windowOpened = true;
                Instantiate(window, UISettings.windowSpawnParent);

                UIData.interfaceUIManager.ToggleButtons(false);
            }
        }

        public void Close()
        {
            UIData.windowOpened = false;
            Destroy(this.gameObject);

            UIData.interfaceUIManager.ToggleButtons(true);
        }
    }
}
