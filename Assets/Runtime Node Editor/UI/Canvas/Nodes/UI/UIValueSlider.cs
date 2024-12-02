using UnityEngine;
using System;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public class UIValueSlider : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private UISlider _uiSlider;

        private void Awake()
        {
            if (!_uiSlider)
            {
                Debug.LogError("Slider component not found!");
                return;
            }

            SetText(_uiSlider.Value.ToString());
        }

        public void OnSliderValueChange()
        {
            if (!_uiSlider)
            {
                Debug.LogError("Slider component not found!");
                return;
            }

            SetText(Math.Round(_uiSlider.Value, 2).ToString());
        }

        private void SetText(string value)
        {
            if (!_text)
            {
                Debug.LogError("Text component not found!");
                return;
            }

            _text.text = "Value: " + value;
        }
    }
}
