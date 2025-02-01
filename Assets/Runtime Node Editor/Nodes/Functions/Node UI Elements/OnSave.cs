using Utils.IO.Serialization;

namespace RuntimeNodeEditor.Node.UI.Functions.Elements
{
    public partial class NodeUIElements
    {
        public void Save(FileWriter writer)
        {
            SaveInputFields(writer, inputFields);
            SaveBooleanButtons(writer, buttons);
            SaveSliders(writer, sliders);
            SaveDropdowns(writer, dropdowns);
        }
    }
}