using RuntimeNodeEditor.UI.Canvas.Node.UI;
using RNE.Template.Node.Pointer;
using Utils.IO.Serialization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utils.Colors;

namespace RNE.Template.Node
{
    public class ColorInputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField]
        private UIColourPicker _colourPicker;

        [Space]

        [SerializeField] private TMP_Dropdown _dropdown;

        [Space]

        [SerializeField] private Slider _redSlider;
        [SerializeField] private Slider _greenSlider;
        [SerializeField] private Slider _blueSlider;

        [Space]

        [SerializeField] private TMP_InputField _redInputfield;
        [SerializeField] private TMP_InputField _greenInputfield;
        [SerializeField] private TMP_InputField _blueInputfield;
        [SerializeField] private TMP_InputField _hexInputfield;

        protected override void CodeToExecute()
        {
            Color color = _colourPicker.CalcualteColor();

            Outputs[0].GetComponent<FloatOutputPointer>().Value = (int)(color.r * 255);
            Outputs[1].GetComponent<FloatOutputPointer>().Value = (int)(color.g * 255);
            Outputs[2].GetComponent<FloatOutputPointer>().Value = (int)(color.b * 255);

            Outputs[3].GetComponent<ColorOutputPointer>().Value =
                new Color(
                    color.r,
                    color.g,
                    color.b);
        }

        protected override void CodeToReset()
        {
            Outputs[0].GetComponent<FloatOutputPointer>().Reset();
            Outputs[1].GetComponent<FloatOutputPointer>().Reset();
            Outputs[2].GetComponent<FloatOutputPointer>().Reset();
            Outputs[3].GetComponent<ColorOutputPointer>().Reset();
        }

        public override void OnSave(FileWriter writer)
        {
            writer.Write(_dropdown.value);
            
            writer.Write(_redSlider.value);
            writer.Write(_greenSlider.value);
            writer.Write(_blueSlider.value);
        }

        public override void OnLoad(FileReader reader)
        {
            _dropdown.value = reader.ReadInt();
            
            _redSlider.value = reader.ReadFloat();
            _greenSlider.value = reader.ReadFloat();
            _blueSlider.value = reader.ReadFloat();
        }
    }
}
