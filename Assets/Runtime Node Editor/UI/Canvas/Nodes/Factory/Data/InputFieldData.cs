using Utils.IO.Serialization;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal string[] Texts 
        { 
            get; 
            private set; 
        }

        private void LoadInputFields(FileReader reader)
        {
            byte numOfInputFields = reader.ReadByte();

            if (numOfInputFields > 0)
            {
                Texts = new string[numOfInputFields];

                for (int i = 0; i < Texts.Length; i++)
                {
                    if (reader.ReadInt() == 0)
                        continue;

                    Texts[i] = reader.ReadString();
                }
            }
        }
    }
}
