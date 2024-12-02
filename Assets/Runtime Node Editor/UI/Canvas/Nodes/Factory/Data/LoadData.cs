namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        public LoadData(byte[] data, ref int index)
        {
            index = LoadInputFields(data, index);
            index = LoadBooleans(data, index);
            index = LoadSliders(data, index);
            index = LoadDropdowns(data, index);
        }
    }
}