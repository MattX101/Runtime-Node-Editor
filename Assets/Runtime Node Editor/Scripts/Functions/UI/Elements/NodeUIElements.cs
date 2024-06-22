using RuntimeNodeEditor.Functions.UI.Component;
using TMPro;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Elements
{
    public class NodeUIElements
    {
        public readonly TMP_InputField[] InputFields;
        public readonly BooleanButton[] Buttons;
        public readonly Slider[] Sliders;

        public NodeUIElements(int numOfInputsFields, int numOfBooleanButtons, int numOfSliders) 
        {
            InputFields = new TMP_InputField[numOfInputsFields];
            Buttons = new BooleanButton[numOfBooleanButtons];
            Sliders = new Slider[numOfSliders];
        }

        public void SetElements(string[] texts, bool[] booleans, float[] values)
        {
            SetInputFields(texts);
            SetBooleans(booleans);
            SetSliders(values);
        }
        public void SetElements(NodeUIElements elementsToCopy)
        {
            SetInputFields(elementsToCopy.InputFields);
            SetBooleans(elementsToCopy.Buttons);
            SetSliders(elementsToCopy.Sliders);
        }

        public void SetInputField(TMP_InputField inputField, string value)
        {
            inputField.text = value;
        }

        private void SetInputFields(string[] values)
        {
            if (InputFields == null)
                return;

            for (int i = 0; i < InputFields.Length; i++)
                SetInputField(InputFields[i], values[i]);
        }
        private void SetInputFields(TMP_InputField[] values)
        {
            if (InputFields == null)
                return;

            for (int i = 0; i < InputFields.Length; i++)
                SetInputField(InputFields[i], values[i].text);
        }

        public void SetBoolean(BooleanButton booleanButton, bool value)
        {
            booleanButton.Toggle(value);
        }

        private void SetBooleans(bool[] values)
        {
            if (Buttons == null)
                return;

            for (int i = 0; i < Buttons.Length; i++)
                SetBoolean(Buttons[i], values[i]);
        }
        private void SetBooleans(BooleanButton[] values)
        {
            if (Buttons == null)
                return;

            for (int i = 0; i < Buttons.Length; i++)
                SetBoolean(Buttons[i], values[i].Toggled);
        }

        public void SetSlider(Slider slider, float value)
        {
            slider.value = value;
        }

        private void SetSliders(float[] values)
        {
            if (Sliders == null)
                return;

            for (int i = 0; i < Sliders.Length; i++)
                SetSlider(Sliders[i], values[i]);
        }
        private void SetSliders(Slider[] values)
        {
            if (Sliders == null)
                return;

            for (int i = 0; i < Sliders.Length; i++)
                SetSlider(Sliders[i], values[i].value);
        }

        public byte[] Save()
        {
            return new UIElementWriter().Save(InputFields, Buttons, Sliders);
        }
    }
}
