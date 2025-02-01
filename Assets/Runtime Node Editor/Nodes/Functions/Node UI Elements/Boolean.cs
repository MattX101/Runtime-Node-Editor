using Utils.IO.Serialization;
using UnityEngine.UI;

namespace RuntimeNodeEditor.Node.UI.Functions.Elements
{
    public partial class NodeUIElements
    {
        public Toggle[] buttons;

        public void SetBoolean(Toggle booleanButton, bool value)
        {
            booleanButton.isOn = value;
        }

        private void SetBooleans(bool[] values)
        {
            if (buttons == null)
                return;

            for (int i = 0; i < buttons.Length; i++)
                SetBoolean(buttons[i], values[i]);
        }
        private void SetBooleans(Toggle[] values)
        {
            if (buttons == null)
                return;

            for (int i = 0; i < buttons.Length; i++)
                SetBoolean(buttons[i], values[i].isOn);
        }

        private void SaveBooleanButtons(FileWriter writer, Toggle[] buttons)
        {
            writer.Write((byte)buttons.Length);

            if (buttons.Length > 0)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    writer.Write(buttons[i].isOn);
                }
            }
        }
    }
}
