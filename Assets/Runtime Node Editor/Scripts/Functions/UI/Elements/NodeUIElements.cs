using RuntimeNodeEditor.Functions.UI.Component;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.Functions.UI.Elements
{
    public class NodeUIElements
    {
        public readonly TMP_InputField[] InputFields;
        public readonly BooleanButton[] Buttons;
        public readonly Slider[] Sliders;
        public readonly Component.Dropdown[] Dropdowns;

        public NodeUIElements(int numOfInputsFields = 0, int numOfBooleanButtons = 0, int numOfSliders = 0, int numOfDropdowns = 0) 
        {
            InputFields = new TMP_InputField[numOfInputsFields];
            Buttons = new BooleanButton[numOfBooleanButtons];
            Sliders = new Slider[numOfSliders];
            Dropdowns = new Component.Dropdown[numOfDropdowns];
        }

        public void SetElements(string[] texts, bool[] booleans, float[] values, int[] dropdownContext, string[] dropdownText)
        {
            SetInputFields(texts);
            SetBooleans(booleans);
            SetSliders(values);
            SetDropdowns(dropdownContext, dropdownText);
        }
        public void SetElements(NodeUIElements elementsToCopy)
        {
            SetInputFields(elementsToCopy.InputFields);
            SetBooleans(elementsToCopy.Buttons);
            SetSliders(elementsToCopy.Sliders);
            SetDropdowns(elementsToCopy.Dropdowns);
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

        public void SetDropdown(Component.Dropdown dropdown, int context, string text)
        {
            dropdown.Context = context;
            dropdown.Text.text = text;
        }

        private void SetDropdowns(int[] context, string[] text)
        {
            if (Dropdowns == null)
                return;

            for (int i = 0;i < Dropdowns.Length; i++)
                SetDropdown(Dropdowns[i], context[i], text[i]);
        }
        private void SetDropdowns(Component.Dropdown[] dropdowns)
        {
            if (Dropdowns == null)
                return;

            for (int i = 0; i < Dropdowns.Length; i++)
                SetDropdown(Dropdowns[i], dropdowns[i].Context, dropdowns[i].Text.text);
        }

        public byte[] Save()
        {
            return new UIElementWriter().Save(
                InputFields, 
                Buttons, 
                Sliders, 
                Dropdowns);
        }
    }
}
