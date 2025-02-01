using Utils.IO.Serialization;
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

        private void SaveDropdowns(FileWriter writer, TMP_Dropdown[] dropdowns)
        {
            writer.Write((byte)dropdowns.Length);
            
            if (dropdowns.Length > 0)
            {
                foreach (TMP_Dropdown dropdown in dropdowns)
                {
                    writer.Write(dropdown.value);
                }
            }
        }
    }
}
