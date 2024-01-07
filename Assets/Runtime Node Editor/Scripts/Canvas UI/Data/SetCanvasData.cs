using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Canvas.Data
{
    public class SetCanvasData : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private CanvasScaler _canvasScaler;

        void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasScaler = GetComponent<CanvasScaler>();

            UpdateCanvasData();
        }

        private void Update()
        {
            UpdateCanvasData();
        }

        public void UpdateCanvasData()
        {
            CanvasData.canvasScale = new Vector2(
                _rectTransform.rect.width / _canvasScaler.referenceResolution.x, 
                _rectTransform.rect.height / _canvasScaler.referenceResolution.y);
        }
    }
}
