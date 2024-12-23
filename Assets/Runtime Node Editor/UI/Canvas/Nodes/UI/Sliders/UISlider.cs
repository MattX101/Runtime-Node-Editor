using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UISlider : MonoBehaviour
    {
        [SerializeField]
        protected Slider slider;

        [SerializeField]
        private Image _fill, _handle;

        [SerializeField]
        private Vector2 _valueRange = new Vector2(0, 1);

        [SerializeField] 
        private Color _color = Color.white;

        private void Awake()
        {
            _fill.color = _color;
            _handle.color = _color;

            if (!slider)
            {
                Debug.LogError("Slider component not found!");
                return;
            }

            slider.minValue = _valueRange.x < _valueRange.y ? _valueRange.x : _valueRange.y;
            slider.maxValue = _valueRange.x > _valueRange.y ? _valueRange.x : _valueRange.y;

            slider.value = slider.minValue;
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

        internal void ChangeColor(Color newColor)
        {
            _fill.color = newColor;
            _handle.color = newColor;
        }
    }
}
