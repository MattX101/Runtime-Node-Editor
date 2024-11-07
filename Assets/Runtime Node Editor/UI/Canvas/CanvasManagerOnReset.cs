using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas
{
    internal class CanvasManagerOnReset : MonoBehaviour
    {
        private CanvasManager _canvasManager;

        private void Awake()
        {
            _canvasManager = FindObjectOfType<CanvasManager>();
        }

        public void Reset()
        {
            _canvasManager.Reset();
        }
    }
}
