using System;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal int[] DropdownContext
        {
            get;
            private set;
        }
        internal string[] DropdownText
        {
            get;
            private set;
        }

        private int LoadDropdowns(byte[] data, int index)
        {
            byte numOfDropdowns = data[index];
            index++;

            if (numOfDropdowns == 0)
            {
                return index;
            }

            DropdownContext = new int[numOfDropdowns];
            DropdownText = new string[numOfDropdowns];

            for (int i = 0; i < numOfDropdowns; i++)
            {
                DropdownContext[i] = BitConverter.ToInt32(data, index);
                index += 4;

                int textLength = BitConverter.ToInt32(data, index);
                index += 4;

                DropdownText[i] = "";
                for (int j = 0; j < textLength; j++)
                {
                    DropdownText[i] += (char)data[index + j];
                }

                index += textLength;
            }

            return index;
        }
    }
}
