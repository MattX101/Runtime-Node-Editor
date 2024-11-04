using System.Collections.Generic;
using System.Linq;
using System;

namespace RuntimeNodeEditor.Node.UIFunctions.Elements
{
    public partial class NodeUIElements
    {
        public Component.Dropdown[] Dropdowns
        {
            get;
        }

        public void SetDropdown(Component.Dropdown dropdown, int context, string text)
        {
            dropdown.SetContext(context);
            dropdown.Text.text = text;
        }

        private void SetDropdowns(int[] context, string[] text)
        {
            if (Dropdowns == null)
                return;

            for (int i = 0; i < Dropdowns.Length; i++)
                SetDropdown(Dropdowns[i], context[i], text[i]);
        }
        private void SetDropdowns(Component.Dropdown[] dropdowns)
        {
            if (Dropdowns == null)
                return;

            for (int i = 0; i < Dropdowns.Length; i++)
                SetDropdown(Dropdowns[i], dropdowns[i].Context, dropdowns[i].Text.text);
        }

        private List<byte> SaveDropdowns(List<byte> bytes, Component.Dropdown[] dropdowns)
        {
            if (dropdowns.Length == 0)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)dropdowns.Length);

            foreach (Component.Dropdown dropdown in dropdowns)
            {
                bytes.AddRange(BitConverter.GetBytes(dropdown.Context));

                bytes.AddRange(BitConverter.GetBytes(dropdown.Text.text.Length));
                bytes.AddRange(dropdown.Text.text.Select(character => (byte)character));
            }

            return bytes;
        }
    }
}
