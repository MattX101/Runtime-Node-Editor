using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Data
{
    internal class DataManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasScaler _canvasScaler;

        [SerializeField]
        private GameObject _nodeUIPanel;

        private void Awake()
        {
            GlobalData.Camera = FindObjectOfType<Camera>();
            GlobalData.CanvasScaler = _canvasScaler;
            GlobalData.NodeUIPanel = _nodeUIPanel;
        }
    }
}
