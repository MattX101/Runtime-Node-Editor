namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal bool[] Booleans 
        { 
            get; 
            private set; 
        }

        private int LoadBooleans(byte[] data, int index)
        {
            byte numOfBooleans = data[index];
            index++;

            if (numOfBooleans == 0)
            {
                return index;
            }

            Booleans = new bool[numOfBooleans];

            for (int i = 0; i < Booleans.Length; i++, index++)
            {
                Booleans[i] = data[index] == 1;
            }

            return index;
        }
    }
}
