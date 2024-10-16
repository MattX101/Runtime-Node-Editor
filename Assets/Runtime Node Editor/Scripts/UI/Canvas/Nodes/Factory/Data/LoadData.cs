using System;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory.Data
{
    public partial class LoadData
    {
        internal readonly string ID;

        internal readonly Vector3 Position;

        public LoadData(byte[] data, ref int index)
        {
            byte length = data[index];
            index++;

            for (int j = 0; j < length; j++)
            {
                ID += (char)data[index + j];
            }
            index += length;

            Position = new Vector3(
                BitConverter.ToSingle(data, index),
                BitConverter.ToSingle(data, index + 4),
                0);
            index += 8;

            index = LoadInputFields(data, index);
            index = LoadBooleans(data, index);
            index = LoadSliders(data, index);
            index = LoadDropdowns(data, index);
        }
    }
}