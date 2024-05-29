using RuntimeNodeEditor.Node.Component;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Node.Elements
{
    public class SaveUIElements
    {
        public byte[] Save(TMP_InputField[] inputFields, BooleanButton[] buttons, Slider[] sliders)
        {
            List<byte> bytes = new List<byte>();

            bytes = SaveInputFields(bytes, inputFields);
            bytes = SaveBooleanButtons(bytes, buttons);
            bytes = SaveSliders(bytes, sliders);

            return bytes.ToArray();
        }

        private List<byte> SaveInputFields(List<byte> bytes, TMP_InputField[] inputFields)
        {
            if (inputFields == null)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)inputFields.Length);

            foreach (TMP_InputField inputField in inputFields)
            {
                bytes.Add((byte)inputField.text.Length);

                if (inputField.text.Length == 0)
                    continue;

                for (int i = 0; i < inputField.text.Length; i++)
                    bytes.Add((byte)inputField.text[i]);
            }

            return bytes;
        }

        private List<byte> SaveBooleanButtons(List<byte> bytes, BooleanButton[] buttons)
        {
            if (buttons == null)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)buttons.Length);

            foreach (BooleanButton button in buttons)
                bytes.Add(button.Toggled == true ? (byte)1 : (byte)0);

            return bytes;
        }

        private List<byte> SaveSliders(List<byte> bytes, Slider[] sliders)
        {
            if (sliders == null)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)sliders.Length);

            foreach (Slider slider in sliders)
                foreach (byte b in BitConverter.GetBytes(slider.value))
                    bytes.Add(b);

            return bytes;
        }
    }
}