using Utils.IO.Serialization;
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

        private void SaveInputFields(FileWriter writer, TMP_InputField[] inputFields)
        {
            writer.Write((byte)inputFields.Length);

            if (inputFields.Length > 0)
            {
                foreach (TMP_InputField inputField in inputFields)
                {
                    writer.Write(inputField.text.Length);

                    if (inputField.text.Length == 0)
                        continue;

                    writer.Write(inputField.text);
                }
            }
        }
    }
}
