namespace RuntimeNodeEditor.Factory.Data
{
    public partial class LoadData
    {
        internal string[] Texts 
        { 
            get; 
            private set; 
        }

        private int LoadInputFields(byte[] data, int index)
        {
            byte numOfInputFields = data[index];
            index++;

            if (numOfInputFields == 0)
            {
                return index;
            }

            Texts = new string[numOfInputFields];

            for (int i = 0; i < Texts.Length; i++)
            {
                byte lengthOfInputField = data[index];
                index++;

                if (lengthOfInputField == 0)
                    continue;

                for (int j = 0; j < lengthOfInputField; j++)
                {
                    Texts[i] += (char)data[index + j];
                }

                index += Texts[i].Length;
            }

            return index;
        }
    }
}
