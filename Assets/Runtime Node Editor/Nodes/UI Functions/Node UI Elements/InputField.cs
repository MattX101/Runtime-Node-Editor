using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace RuntimeNodeEditor.Node.UIFunctions.Elements
{
    public partial class NodeUIElements
    {
        public TMP_InputField[] InputFields
        {
            get;
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
    }
}
