using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UIColourPicker : MonoBehaviour
    {
        [Header("Sliders")]
        [SerializeField] private UISlider _uiSliderA;
        [SerializeField] private UISlider _uiSliderB;
        [SerializeField] private UISlider _uiSliderC;

        [Header("Texts")]
        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private TMP_InputField _hexValueInputfield;

        [Header("Image")]
        [SerializeField] private RawImage _image;

        private HexValidator _hexValidator;

        private void Awake()
        {
            _hexValidator = new HexValidator();
            _hexValueInputfield.inputValidator = _hexValidator;
        }

        private void Start()
        {
            SetText(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
            SetHexField(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
            SetColor(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
        }

        public void OnSliderValueChange()
        {
            SetText(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
            SetHexField(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
            SetColor(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
        }

        public void OnHexFieldEdit()
        {
            string hex = _hexValueInputfield.text;
            for (int i = 0; i < GetNumOfAppends(hex); i++)
            {
                hex += '0';
            }

            _uiSliderA.Value = (_hexValidator.HexCodeToInt(hex[0]) * 16) + _hexValidator.HexCodeToInt(hex[1]);
            _uiSliderB.Value = (_hexValidator.HexCodeToInt(hex[2]) * 16) + _hexValidator.HexCodeToInt(hex[3]);
            _uiSliderC.Value = (_hexValidator.HexCodeToInt(hex[4]) * 16) + _hexValidator.HexCodeToInt(hex[5]);

            SetHexField(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
            SetColor(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value);
        }

        private int GetNumOfAppends(string hex)
        {
            return hex.Length == 0 ? 6 : 6 - hex.Length;
        }

        private void SetText(float a, float b, float c)
        {
            _valueText.text = a.ToString() + " - " + b.ToString() + " - " + c.ToString();
        }

        private void SetHexField(float a, float b, float c)
        {
            float r1 = a / 16.0f;
            float g1 = b / 16.0f;
            float b1 = c / 16.0f;

            _hexValueInputfield.text = ""
                + _hexValidator.HexCodes[(int)r1]
                + _hexValidator.HexCodes[(int)(r1 % 1 * 16)]
                + _hexValidator.HexCodes[(int)g1]
                + _hexValidator.HexCodes[(int)(g1 % 1 * 16)]
                + _hexValidator.HexCodes[(int)b1]
                + _hexValidator.HexCodes[(int)(b1 % 1 * 16)];
        }

        private void SetColor(float a, float b, float c)
        {
            _image.color = new Color(a / 255.0f, b / 255.0f, c / 255.0f);
        }
    }
}
