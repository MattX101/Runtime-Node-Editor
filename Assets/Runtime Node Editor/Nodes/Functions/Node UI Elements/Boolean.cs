using System.Collections.Generic;
using System.Linq;
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

        private List<byte> SaveBooleanButtons(List<byte> bytes, Toggle[] buttons)
        {
            if (buttons.Length == 0)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)buttons.Length);
            bytes.AddRange(buttons.Select(button => button.isOn ? (byte)1 : (byte)0));

            return bytes;
        }
    }
}
