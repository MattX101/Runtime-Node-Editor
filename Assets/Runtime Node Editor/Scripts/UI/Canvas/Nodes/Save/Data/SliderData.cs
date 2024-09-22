using System;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Save.Data
{
    public partial class LoadData
    {
        internal float[] SliderValues
        {
            get;
            private set;
        }

        private int LoadSliders(byte[] data, int index)
        {
            byte numOfSliders = data[index];
            index++;

            if (numOfSliders == 0)
            {
                return index;
            }

            SliderValues = new float[numOfSliders];

            for (int i = 0; i < SliderValues.Length; i++, index += 4)
            {
                SliderValues[i] = BitConverter.ToSingle(data, index);
            }

            return index;
        }
    }
}
