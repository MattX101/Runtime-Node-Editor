using RuntimeNodeEditor.Node.Component;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

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

        public void SetElements(string[] texts, bool[] toggles, float[] values)
        {
            SetInputFields(texts);
            SetBooleans(toggles);
            SetSliders(values);
        }
        public void SetElements(NodeUIElements elementsToCopy)
        {
            SetInputFields(elementsToCopy.inputFields);
            SetBooleans(elementsToCopy.buttons);
            SetSliders(elementsToCopy.sliders);
        }

        private void SetInputFields(string[] values)
        {
            if (inputFields == null)
                return;

            for (int i = 0; i < inputFields.Length; i++)
                inputFields[i].text = values[i];
        }
        private void SetInputFields(TMP_InputField[] values)
        {
            if (inputFields == null)
                return;

            for (int i = 0; i < inputFields.Length; i++)
                inputFields[i].text = values[i].text;
        }

        private void SetBooleans(bool[] values)
        {
            if (buttons == null)
                return;

            for (int i = 0; i < buttons.Length; i++)
                buttons[i].Toggle(values[i]);
        }
        private void SetBooleans(BooleanButton[] values)
        {
            if (buttons == null)
                return;

            for (int i = 0; i < buttons.Length; i++)
                buttons[i].Toggle(values[i].Toggled);
        }

        private void SetSliders(float[] values)
        {
            if (sliders == null)
                return;

            for (int i = 0; i < sliders.Length; i++)
                sliders[i].value = values[i];
        }
        private void SetSliders(Slider[] values)
        {
            if (sliders == null)
                return;

            for (int i = 0; i < sliders.Length; i++)
                sliders[i].value = values[i].value;
        }

        public byte[] Save(string nodeId, Vector3 position)
        {
            return new SaveUIElements().Save(nodeId, position, inputFields, buttons, sliders);
        }
    }
}
