using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public class UISlider : MonoBehaviour
    {
        [SerializeField]
        protected Slider slider;

        [SerializeField]
        private Image _fill, _handle;

        [SerializeField]
        private Vector2 _valueRange = new Vector2(0, 1);

        [SerializeField]
        private float _startValue = 0.0f;

        [SerializeField] 
        private Color _color = Color.white;
        public Color Color => _handle.color;

        private void Awake()
        {
            if (_fill != null)
            {
                _fill.color = _color;
            }
            _handle.color = _color;

            if (!slider)
            {
                Debug.LogError("Slider component not found!");
                return;
            }

            slider.minValue = _valueRange.x < _valueRange.y ? _valueRange.x : _valueRange.y;
            slider.maxValue = _valueRange.x > _valueRange.y ? _valueRange.x : _valueRange.y;

            slider.value = _startValue;
        }

        internal float Value
        {
            get 
            {
                if (!slider)
                {
                    Debug.LogError("Slider component not found!");
                    return 0.0f;
                }

                return slider.value;
            }
            set
            {
                if (!slider)
                {
                    Debug.LogError("Slider component not found!");
                    return;
                }

                slider.value = value;
            }
        }

        public void ChangeFillColor(Color newColor)
        {
            _fill.color = newColor;
        }

        public void ChangeHandleColor(Color newColor)
        {
            _handle.color = newColor;
        }

        public void SetMinValue(float value)
        {
            slider.minValue = value;
        }

        public void SetMaxValue(float value)
        {
            slider.maxValue = value;
        }
    }
}
