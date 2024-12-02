using System;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal int[] DropdownValue
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

            DropdownValue = new int[numOfDropdowns];

            for (int i = 0; i < numOfDropdowns; i++)
            {
                DropdownValue[i] = BitConverter.ToInt32(data, index);
                index += 4;
            }

            return index;
        }
    }
}
