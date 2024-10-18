using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Data
{
    internal class DataManager : MonoBehaviour
    {
        [SerializeField]
        private new Camera camera;

        [SerializeField]
        private CanvasScaler canvasScaler;

        [SerializeField]
        private GameObject nodeUIPanel;

        private void Awake()
        {
            CanvasData.Camera = camera;
            CanvasData.CanvasScaler = canvasScaler;

            UIData.NodeUIPanel = nodeUIPanel;
        }
    }
}
