using System;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Save
{
    public class LoadData
    {
        public readonly string id;

        public readonly Vector3 position;

        private string[] _texts;
        public string[] Texts => _texts;

        private bool[] _booleans;
        public bool[] Booleans => _booleans;

        private float[] _values;
        public float[] Values => _values;

        public readonly int endIndex;

        public LoadData(byte[] data, int index)
        {
            byte length = data[index];
            index++;

            for (int j = 0; j < length; j++)
                id += (char)data[index + j];
            index += length;

            position = new Vector3(
                BitConverter.ToSingle(data, index),
                BitConverter.ToSingle(data, index + 4),
                0);
            index += 8;

            index = LoadInputFields(data, index);
            index = LoadBooleans(data, index);
            index = LoadSliders(data, index);
            endIndex = index;
        }

        private int LoadInputFields(byte[] data, int index)
        {
            byte numOfInputFields = data[index];
            index++;

            if (numOfInputFields == 0)
                return index;

            _texts = new string[numOfInputFields];

            for (int i = 0; i < _texts.Length; i++)
            {
                byte lengthOfInputField = data[index];
                index++;

                if (lengthOfInputField == 0)
                    continue;

                for (int j = 0; j < lengthOfInputField; j++)
                    _texts[i] += (char)data[index + j];
                index += _texts[i].Length;
            }

            return index;
        }

        private int LoadBooleans(byte[] data, int index)
        {
            byte numOfBooleans = data[index];
            index++;

            if (numOfBooleans == 0)
                return index;

            _booleans = new bool[numOfBooleans];

            for (int i = 0; i < _booleans.Length; i++, index++)
                _booleans[i] = data[index] == 1 ? true : false;

            return index;
        }

        private int LoadSliders(byte[] data, int index)
        {
            byte numOfSliders = data[index];
            index++;

            if (numOfSliders == 0)
                return index;

            _values = new float[numOfSliders];

            for (int i = 0; i < _values.Length; i++, index += 4)
                _values[i] = BitConverter.ToSingle(data, index);

            return index;
        }
    }
}