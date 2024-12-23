using UnityEngine;
using System;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UISliderWithPreview : UISlider
    {
        [SerializeField]
        private TMP_Text _text;

        private void Start()
        {
            _text.text = Math.Round(slider.value, 2).ToString();
        }

        public void OnValueChange()
        {
            _text.text = Math.Round(slider.value, 2).ToString();
        }
    }
}
