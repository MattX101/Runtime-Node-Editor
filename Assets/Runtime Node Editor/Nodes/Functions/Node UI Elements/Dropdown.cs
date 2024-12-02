using System.Collections.Generic;
using System;
using TMPro;

namespace RuntimeNodeEditor.Node.UI.Functions.Elements
{
    public partial class NodeUIElements
    {
        public TMP_Dropdown[] dropdowns;

        public void SetDropdown(TMP_Dropdown dropdown, int value)
        {
            dropdown.value = value;
        }

        private void SetDropdowns(int[] value)
        {
            if (dropdowns == null)
                return;

            for (int i = 0; i < dropdowns.Length; i++)
            {
                SetDropdown(dropdowns[i], value[i]);
            }
        }
        private void SetDropdowns(TMP_Dropdown[] dropdowns)
        {
            if (dropdowns == null)
                return;

            for (int i = 0; i < dropdowns.Length; i++)
            {
                SetDropdown(dropdowns[i], dropdowns[i].value);
            }
        }

        private List<byte> SaveDropdowns(List<byte> bytes, TMP_Dropdown[] dropdowns)
        {
            if (dropdowns.Length == 0)
            {
                bytes.Add(0);

                return bytes;
            }

            bytes.Add((byte)dropdowns.Length);

            foreach (TMP_Dropdown dropdown in dropdowns)
            {
                bytes.AddRange(BitConverter.GetBytes(dropdown.value));
            }

            return bytes;
        }
    }
}
