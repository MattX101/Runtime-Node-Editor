using Utils.IO.Serialization;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        public LoadData(FileReader reader)
        {
            LoadInputFields(reader);
            LoadBooleans(reader);
            LoadSliders(reader);
            LoadDropdowns(reader);
        }
    }
}