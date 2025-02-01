using Utils.IO.Serialization;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal float[] SliderValues
        {
            get;
            private set;
        }

        private void LoadSliders(FileReader reader)
        {
            byte numOfSliders = reader.ReadByte();

            if (numOfSliders > 0)
            {
                SliderValues = new float[numOfSliders];

                for (int i = 0; i < SliderValues.Length; i++)
                {
                    SliderValues[i] = reader.ReadFloat();
                }
            }
        }
    }
}
