using Utils.Colors;
using Utils.Colors.Model;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class UIColourPicker : MonoBehaviour
    {
        [Header("Dropdown")]
        [SerializeField] private TMP_Dropdown _colorModelDropdown;

        [Header("Sliders")]
        [SerializeField] private UISlider _uiSliderA;
        [SerializeField] private UISlider _uiSliderB;
        [SerializeField] private UISlider _uiSliderC;

        [Header("Texts")]
        [SerializeField] private TMP_InputField _redText;
        [SerializeField] private TMP_InputField _greenText;
        [SerializeField] private TMP_InputField _blueText;

        [Space]

        [SerializeField] private TMP_InputField _hexValueInputfield;

        [Header("Image")]
        [SerializeField] private RawImage _image;

        private HexValidator _hexValidator;

        private bool _skipSliderOnChangeUpdate = false;

        private void Awake()
        {
            _hexValidator = new HexValidator();
            _hexValueInputfield.inputValidator = _hexValidator;
        }

        private void Start()
        {
            SetText((int)(_uiSliderA.Value * 255), (int)(_uiSliderB.Value * 255), (int)(_uiSliderC.Value * 255));
            SetHexField();
            SetColor(new Color(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value));
        }

        public void OnDropdownValueChange()
        {
            _skipSliderOnChangeUpdate = true;

            if (_colorModelDropdown.value == 1)
            {
                HSL hsl = ColorConversion.RGBToHSL(_image.color);

                SetSliders(hsl.Hue / 360.0f, hsl.Saturation, hsl.Lightness);
                _skipSliderOnChangeUpdate = false;

                SetText((float)Math.Round(hsl.Hue, 2), (float)Math.Round(hsl.Saturation * 100, 2), (float)Math.Round(hsl.Lightness * 100, 2));

                return;
            }
            else if (_colorModelDropdown.value == 2)
            {
                HSV hsv = ColorConversion.RGBToHSV(_image.color);

                SetSliders(hsv.Hue / 360.0f, hsv.Saturation, hsv.Value);
                _skipSliderOnChangeUpdate = false;

                SetText((float)Math.Round(hsv.Hue, 2), (float)Math.Round(hsv.Saturation * 100, 2), (float)Math.Round(hsv.Value * 100, 2));

                return;
            }

            SetSliders(_image.color.r, _image.color.g, _image.color.b);
            _skipSliderOnChangeUpdate = false;

            SetText((int)(_image.color.r * 255), (int)(_image.color.g * 255), (int)(_image.color.b * 255));

            OnSliderValueChange();
        }

        public void OnSliderValueChange()
        {
            if (_skipSliderOnChangeUpdate)
                return;

            SetHexField();

            switch (_colorModelDropdown.value)
            {
                case 0:
                    SetText((int)(_uiSliderA.Value * 255), (int)(_uiSliderB.Value * 255), (int)(_uiSliderC.Value * 255));
                    SetColor(new Color(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value));
                    break;
                case 1:
                    SetText((float)Math.Round(_uiSliderA.Value * 360, 2), (float)Math.Round(_uiSliderB.Value * 100, 2), (float)Math.Round(_uiSliderC.Value * 100, 2));
                    SetColor(ColorConversion.HSLToRGB(new HSL(_uiSliderA.Value * 360, _uiSliderB.Value, _uiSliderC.Value)));
                    break;
                case 2:
                    SetText((float)Math.Round(_uiSliderA.Value * 360, 2), (float)Math.Round(_uiSliderB.Value * 100, 2), (float)Math.Round(_uiSliderC.Value * 100, 2));
                    SetColor(ColorConversion.HSVToRGB(new HSV(_uiSliderA.Value * 360, _uiSliderB.Value, _uiSliderC.Value)));
                    break;
                default:
                    SetText((int)(_uiSliderA.Value * 255), (int)(_uiSliderB.Value * 255), (int)(_uiSliderC.Value * 255));
                    SetColor(new Color(_uiSliderA.Value, _uiSliderB.Value, _uiSliderC.Value));
                    break;
            }
        }

        public void OnHexFieldEdit()
        {
            _skipSliderOnChangeUpdate = true;

            string hex = _hexValueInputfield.text;
            switch (_hexValueInputfield.text.Length)
            {
                case 0:
                    hex = "000000";
                    break;
                case 1:
                    hex += "00000";
                    break;
                case 2:
                    hex += "0000";
                    break;
                case 3:
                    hex += "000";
                    break;
                case 4:
                    hex += "00";
                    break;
                case 5:
                    hex += "0";
                    break;
                case 6:
                    break;
                default:
                    hex = "000000";
                    break;
            }

            Color color = ColorConversion.HEXToRGB(new HEX(hex));

            if (_colorModelDropdown.value == 1)
            {
                HSL hsl = ColorConversion.RGBToHSL(color);

                SetSliders(hsl.Hue / 360.0f, hsl.Saturation, hsl.Lightness);
                SetText((float)Math.Round(hsl.Hue, 2), (float)Math.Round(hsl.Saturation * 100, 2), (float)Math.Round(hsl.Lightness * 100, 2));
            }
            else if (_colorModelDropdown.value == 2)
            {
                HSV hsv = ColorConversion.RGBToHSV(color);

                SetSliders(hsv.Hue / 360.0f, hsv.Saturation, hsv.Value);
                SetText((float)Math.Round(hsv.Hue, 2), (float)Math.Round(hsv.Saturation * 100, 2), (float)Math.Round(hsv.Value * 100, 2));
            }
            else
            {
                SetSliders(color.r, color.g, color.b);
                SetText((int)(color.r * 255), (int)(color.g * 255), (int)(color.b * 255));
            }

            SetColor(color);
            SetHexField();

            _skipSliderOnChangeUpdate = false;
        }

        private void SetSliders(float a, float b, float c)
        {
            _uiSliderA.Value = a;
            _uiSliderB.Value = b;
            _uiSliderC.Value = c;
        }

        private void SetText(float a, float b, float c)
        {
            _redText.text = a.ToString();
            _greenText.text = b.ToString();
            _blueText.text = c.ToString();
        }

        private void SetHexField()
        {
            _hexValueInputfield.text = ColorConversion.RGBToHex(_image.color).Hex;
        }

        private void SetColor(Color c)
        {
            _image.color = c;
        }
    }
}
