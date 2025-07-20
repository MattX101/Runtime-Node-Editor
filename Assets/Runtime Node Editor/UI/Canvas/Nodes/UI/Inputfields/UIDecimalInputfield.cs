using UnityEngine;
using System;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UIDecimalInputfield : UIInputField
    {
        [SerializeField]
        private bool _toggleValueRange;

        [SerializeField]
        private Vector2 _valueRange;

        private void Awake()
        {
            _inputField.interactable = _active;

            if (_toggleValueRange)
            {
                if (_valueRange.y < _valueRange.x)
                {
                    float min = _valueRange.x;
                    float max = _valueRange.y;

                    _valueRange.x = max;
                    _valueRange.y = min;
                }
            }
        }

        public void OnValueChange()
        {
            if (_inputField.text.Length == 0)
                return;

            if (_inputField.text.Length == 1 && _inputField.text[0] == '-')
                return;

            if (_inputField.text[^1] == '.')
                return;

            float parsedValue = 0;

            try
            {
                parsedValue = float.Parse(_inputField.text);
            }
            catch (OverflowException)
            {
                parsedValue =
                    _inputField.text[0] == '-' ?
                    float.MinValue :
                    float.MaxValue;
            }
            finally
            {
                if (_toggleValueRange)
                {
                    parsedValue = Mathf.Clamp(
                        parsedValue,
                        _valueRange.x,
                        _valueRange.y);
                }
                else
                {
                    parsedValue = Mathf.Clamp(
                        parsedValue,
                        -99999.99f,
                        99999.99f);
                }

                _inputField.text = parsedValue.ToString();
            }
        }
    }
}
