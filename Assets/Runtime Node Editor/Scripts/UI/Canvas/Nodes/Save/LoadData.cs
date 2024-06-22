using System;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Save
{
    public class LoadData
    {
        public readonly string ID;

        public readonly Vector3 Position;

        public string[] Texts { get; private set; }
        public bool[] Booleans { get; private set; }
        public float[] Values  { get; private set; }

        public readonly int EndIndex;

        public LoadData(byte[] data, int index)
        {
            byte length = data[index];
            index++;

            for (int j = 0; j < length; j++)
                ID += (char)data[index + j];
            index += length;

            Position = new Vector3(
                BitConverter.ToSingle(data, index),
                BitConverter.ToSingle(data, index + 4),
                0);
            index += 8;

            index = LoadInputFields(data, index);
            index = LoadBooleans(data, index);
            index = LoadSliders(data, index);
            EndIndex = index;
        }

        private int LoadInputFields(byte[] data, int index)
        {
            byte numOfInputFields = data[index];
            index++;

            if (numOfInputFields == 0)
                return index;

            Texts = new string[numOfInputFields];

            for (int i = 0; i < Texts.Length; i++)
            {
                byte lengthOfInputField = data[index];
                index++;

                if (lengthOfInputField == 0)
                    continue;

                for (int j = 0; j < lengthOfInputField; j++)
                    Texts[i] += (char)data[index + j];
                index += Texts[i].Length;
            }

            return index;
        }

        private int LoadBooleans(byte[] data, int index)
        {
            byte numOfBooleans = data[index];
            index++;

            if (numOfBooleans == 0)
                return index;

            Booleans = new bool[numOfBooleans];

            for (int i = 0; i < Booleans.Length; i++, index++)
                Booleans[i] = data[index] == 1 ? true : false;

            return index;
        }

        private int LoadSliders(byte[] data, int index)
        {
            byte numOfSliders = data[index];
            index++;

            if (numOfSliders == 0)
                return index;

            Values = new float[numOfSliders];

            for (int i = 0; i < Values.Length; i++, index += 4)
                Values[i] = BitConverter.ToSingle(data, index);

            return index;
        }
    }
}