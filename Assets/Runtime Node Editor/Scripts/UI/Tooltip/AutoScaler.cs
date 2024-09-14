using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Tooltip
{
    public class AutoScaler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private CanvasScaler _scaler;

        // TODO - Change from Update() to an OnValueChange method
        private void Update()
        {
            if (_camera.pixelWidth > _camera.pixelHeight)
            {
                _scaler.matchWidthOrHeight = 0;
            }
            else
            {
                _scaler.matchWidthOrHeight = 1;
            }
        }
    }
}
