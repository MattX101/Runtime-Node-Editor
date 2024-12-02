using UnityEngine;
using System;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UIIntegerInputfield : UIInputField
    {
        [SerializeField]
        private bool _toggleValueRange;

        [SerializeField]
        private Vector2Int _valueRange;

        private void Awake()
        {
            _inputField.interactable = _active;

            if (_toggleValueRange)
            {
                if (_valueRange.y < _valueRange.x)
                {
                    int min = _valueRange.x;
                    int max = _valueRange.y;

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
            
            int parsedValue = 0;

            try
            {
                parsedValue = int.Parse(_inputField.text);
            }
            catch (OverflowException)
            {
                parsedValue =
                    _inputField.text[0] == '-' ?
                    int.MinValue :
                    int.MaxValue;
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

                _inputField.text = parsedValue.ToString();
            }
        }
    }
}
