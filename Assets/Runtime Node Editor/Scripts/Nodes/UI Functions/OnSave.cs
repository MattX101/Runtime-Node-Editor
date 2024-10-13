using System.Collections.Generic;

namespace RuntimeNodeEditor.Functions.UI.Elements
{
    public partial class NodeUIElements
    {
        public byte[] Save()
        {
            List<byte> bytes = new List<byte>();

            bytes = SaveInputFields(bytes, InputFields);
            bytes = SaveBooleanButtons(bytes, Buttons);
            bytes = SaveSliders(bytes, Sliders);
            bytes = SaveDropdowns(bytes, Dropdowns);

            return bytes.ToArray();
        }
    }
}