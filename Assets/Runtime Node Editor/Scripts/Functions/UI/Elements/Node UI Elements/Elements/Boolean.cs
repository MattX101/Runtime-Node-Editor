using RuntimeNodeEditor.Functions.UI.Component;
using System.Collections.Generic;
using System.Linq;

namespace RuntimeNodeEditor.Functions.UI.Elements
{
    public partial class NodeUIElements
    {
        public readonly BooleanButton[] Buttons;

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
    }
}
