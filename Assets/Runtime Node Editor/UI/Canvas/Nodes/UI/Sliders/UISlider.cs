using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UISlider : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _valueRange = new Vector2(0, 1);

        [SerializeField]
        private Image _fill, _handle;

        [SerializeField] 
        private Color _color = Color.white;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();

            _fill.color = _color;
            _handle.color = _color;

            if (!_slider)
            {
                Debug.LogError("Slider component not found!");
                return;
            }

            _slider.minValue = _valueRange.x < _valueRange.y ? _valueRange.x : _valueRange.y;
            _slider.maxValue = _valueRange.x > _valueRange.y ? _valueRange.x : _valueRange.y;

            _slider.value = _slider.minValue;
        }

        internal float Value
        {
            get 
            {
                if (!_slider)
                {
                    Debug.LogError("Slider component not found!");
                    return 0.0f;
                }

                return _slider.value;
            }
            set
            {
                if (!_slider)
                {
                    Debug.LogError("Slider component not found!");
                    return;
                }

                _slider.value = value;
            }
        }
    }
}
