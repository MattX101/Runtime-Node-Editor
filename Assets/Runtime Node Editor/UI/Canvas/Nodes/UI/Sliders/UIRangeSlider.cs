using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public class UIRangeSlider : MonoBehaviour
    {
        [SerializeField]
        private Slider _min;
        [SerializeField]
        private Slider _max;

        [Space]

        [SerializeField]
        private TMP_Text _minText;
        [SerializeField]
        private TMP_Text _maxText;

        [Space]

        [SerializeField]
        private RawImage _previewBackground;
        [SerializeField]
        private RawImage _preview;
        
        private Color _outOfBounds;

        [Space]

        [SerializeField]
        private Vector2 _bounds = new Vector2(0, 1);

        [SerializeField]
        private Vector2 _startRange = new Vector2(0, 1);

        public float Min => _min.value;
        public float Max => _max.value;

        public Vector2 Range => new Vector2(Min, Max);

        /// Since on Awake the min & max slider values are being set, ...
        /// OnSliderValueChange is being called due to OnValueChange, ..
        /// so skip is used to prevent the functiom from being called
        private bool _skip = false;

        private void Awake()
        {
            _skip = true;

            if (_bounds.x > _bounds.y)
            {
                float x = _bounds.x;
                float y = _bounds.y;

                _bounds.x = y;
                _bounds.y = x;
            }

            if (_startRange.x > _startRange.y)
            {
                float x = _startRange.x;
                float y = _startRange.y;

                _startRange.x = y;
                _startRange.y = x;
            }

            _min.minValue = _bounds.x;
            _max.minValue = _bounds.x;

            _min.maxValue = _bounds.y;
            _max.maxValue = _bounds.y;

            _min.value = _startRange.x;
            _max.value = _startRange.y;

            _skip = false;
        }

        private void Start()
        {
            _outOfBounds = _previewBackground.color;

            OnSliderValueChange();
        }

        public void OnSliderValueChange(bool isMin = true)
        {
            if (_skip)
                return;

            if (isMin)
            {
                if (_min.value > _max.value)
                {
                    _min.value = _max.value;
                }
            }
            else
            {
                if (_max.value < _min.value)
                {
                    _max.value = _min.value;
                }
            }

            _minText.text = Math.Round(_min.value, 2).ToString();
            _maxText.text = Math.Round(_max.value, 2).ToString();

            Color[] colors = new Color[100];
            for (int i = 0; i < colors.Length; i++)
            {
                float t = Mathf.Lerp(_bounds.x, _bounds.y, i / 100.0f);
                if (t >= _min.value && t <= _max.value)
                {
                    colors[i] = new Color(1, 1, 1, 1);
                }
                else
                {
                    colors[i] = _outOfBounds;
                }
            }

            Texture2D gradient = new Texture2D(colors.Length, 1);
            gradient.wrapMode = TextureWrapMode.Clamp;
            gradient.filterMode = FilterMode.Point;
            gradient.SetPixels(colors);
            gradient.Apply();

            _preview.texture = gradient;
        }
    }
}
