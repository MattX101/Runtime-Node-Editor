using RuntimeNodeEditor.Functions.UI.Component;
using System.Collections.Generic;
using System;
using System.Linq;
using TMPro;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Functions.UI.Elements
{
    internal class UIElementWriter
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
            if (inputFields.Length == 0)
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

                bytes.AddRange(inputField.text.Select(character => (byte)character));
            }

            return bytes;
        }

        private List<byte> SaveBooleanButtons(List<byte> bytes, BooleanButton[] buttons)
        {
            if (buttons.Length == 0)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)buttons.Length);
            bytes.AddRange(buttons.Select(button => button.Toggled ? (byte)1 : (byte)0));

            return bytes;
        }

        private List<byte> SaveSliders(List<byte> bytes, Slider[] sliders)
        {
            if (sliders.Length == 0)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)sliders.Length);
            bytes.AddRange(sliders.SelectMany(slider => BitConverter.GetBytes(slider.value)));

            return bytes;
        }
    }
}