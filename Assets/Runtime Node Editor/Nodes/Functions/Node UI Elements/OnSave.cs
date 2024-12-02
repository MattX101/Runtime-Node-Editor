using System.Collections.Generic;

namespace RuntimeNodeEditor.Node.UI.Functions.Elements
{
    public partial class NodeUIElements
    {
        public byte[] Save()
        {
            List<byte> bytes = new List<byte>();

            bytes = SaveInputFields(bytes, inputFields);
            bytes = SaveBooleanButtons(bytes, buttons);
            bytes = SaveSliders(bytes, sliders);
            bytes = SaveDropdowns(bytes, dropdowns);

            return bytes.ToArray();
        }
    }
}