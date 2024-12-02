using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace RuntimeNodeEditor.Node.UI.Functions.Elements
{
    public partial class NodeUIElements
    {
        public TMP_InputField[] inputFields;

        public void SetInputField(TMP_InputField inputField, string value)
        {
            inputField.text = value;
        }

        private void SetInputFields(string[] values)
        {
            if (inputFields == null)
                return;

            for (int i = 0; i < inputFields.Length; i++)
            {
                SetInputField(inputFields[i], values[i]);
            }
        }
        private void SetInputFields(TMP_InputField[] values)
        {
            if (inputFields == null)
                return;

            for (int i = 0; i < inputFields.Length; i++)
            {
                SetInputField(inputFields[i], values[i].text);
            }
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
