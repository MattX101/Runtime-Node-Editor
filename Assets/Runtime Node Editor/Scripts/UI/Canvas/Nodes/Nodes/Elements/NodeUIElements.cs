using RuntimeNodeEditor.Node.Component;
using TMPro;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Node.Elements
{
    public class NodeUIElements
    {
        public TMP_InputField[] inputFields = null;
        public BooleanButton[] buttons = null;
        public Slider[] sliders = null;

        public NodeUIElements(int numOfInputsFields, int numOfBooleanButtons, int numOfSliders) 
        {
            inputFields = new TMP_InputField[numOfInputsFields];
            buttons = new BooleanButton[numOfBooleanButtons];
            sliders = new Slider[numOfSliders];
        }

        public void SetElements(NodeUILoadData elementsToLoad)
        {
            SetInputFields(elementsToLoad.Texts);
            SetBooleans(elementsToLoad.Booleans);
            SetSliders(elementsToLoad.Values);
        }
        public void SetElements(NodeUIElements elementsToCopy)
        {
            SetInputFields(elementsToCopy.inputFields);
            SetBooleans(elementsToCopy.buttons);
            SetSliders(elementsToCopy.sliders);
        }

        public void SetInputField(TMP_InputField inputField, string value)
        {
            inputField.text = value;
        }

        private void SetInputFields(string[] values)
        {
            if (inputFields == null)
                return;

            for (int i = 0; i < inputFields.Length; i++)
                SetInputField(inputFields[i], values[i]);
        }
        private void SetInputFields(TMP_InputField[] values)
        {
            if (inputFields == null)
                return;

            for (int i = 0; i < inputFields.Length; i++)
                SetInputField(inputFields[i], values[i].text);
        }

        public void SetBoolean(BooleanButton booleanButton, bool value)
        {
            booleanButton.Toggle(value);
        }

        private void SetBooleans(bool[] values)
        {
            if (buttons == null)
                return;

            for (int i = 0; i < buttons.Length; i++)
                SetBoolean(buttons[i], values[i]);
        }
        private void SetBooleans(BooleanButton[] values)
        {
            if (buttons == null)
                return;

            for (int i = 0; i < buttons.Length; i++)
                SetBoolean(buttons[i], values[i].Toggled);
        }

        public void SetSlider(Slider slider, float value)
        {
            slider.value = value;
        }

        private void SetSliders(float[] values)
        {
            if (sliders == null)
                return;

            for (int i = 0; i < sliders.Length; i++)
                SetSlider(sliders[i], values[i]);
        }
        private void SetSliders(Slider[] values)
        {
            if (sliders == null)
                return;

            for (int i = 0; i < sliders.Length; i++)
                SetSlider(sliders[i], values[i].value);
        }

        public byte[] Save()
        {
            return new SaveUIElements().Save(inputFields, buttons, sliders);
        }
    }
}
