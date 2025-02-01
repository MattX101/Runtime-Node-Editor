using Utils.IO.Serialization;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal int[] DropdownValue
        {
            get;
            private set;
        }

        private void LoadDropdowns(FileReader reader)
        {
            byte numOfDropdowns = reader.ReadByte();

            if (numOfDropdowns > 0)
            {
                DropdownValue = new int[numOfDropdowns];

                for (int i = 0; i < numOfDropdowns; i++)
                {
                    DropdownValue[i] = reader.ReadInt();
                }
            }
        }
    }
}
