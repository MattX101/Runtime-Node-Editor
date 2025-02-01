using Utils.IO.Serialization;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal bool[] Booleans 
        { 
            get; 
            private set; 
        }

        private void LoadBooleans(FileReader reader)
        {
            byte numOfBooleans = reader.ReadByte();

            if (numOfBooleans > 0)
            {
                Booleans = new bool[numOfBooleans];

                for (int i = 0; i < Booleans.Length; i++)
                {
                    Booleans[i] = reader.ReadBool();
                }
            }
        }
    }
}
