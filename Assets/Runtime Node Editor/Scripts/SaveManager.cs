using RuntimeNodeEditor.Functions.Seed;
using RuntimeNodeEditor.UI.Canvas;
using RuntimeNodeEditor.UI.Node;
using RuntimeNodeEditor.Utils.IO.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace RuntimeNodeEditor
{
    public class SaveManager : MonoBehaviour
    {
        private IOSelection _iOSelection;
        private string _saveDirectory = null;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private SeedManager _seedManager;

        [SerializeField]
        private NodeUIManager _nodeUIManager;

        private List<byte> _data = new List<byte>();

        private const string saveExtension = "data";

        public SaveManager()
        {
            _iOSelection = new IOSelection();
        }

        public void Save()
        {
            if (_saveDirectory == null)
            {
                SaveAs();

                return;
            }

            WriteData();
        }

        public void SaveAs()
        {
            _saveDirectory = _iOSelection.SaveFile("Save", saveExtension);

            WriteData();
        }

        private void WriteData()
        {
            _data.Clear();

            foreach (byte b in _seedManager.Save()) _data.Add(b);
            foreach (byte b in Zoom.Save()) _data.Add(b);
            foreach (byte b in _nodeUIManager.Save()) _data.Add(b);

            File.WriteAllBytes(_saveDirectory, _data.ToArray());
        }

        public void Load()
        {
            string path = _iOSelection.SelectFile(saveExtension);

            if (path == null)
            {
                Debug.LogWarning("Save file was not opened!");

                return;
            }

            int position = 0;
            byte[] data = File.ReadAllBytes(path);

            _seedManager.seed = BitConverter.ToInt32(data, position);
            position += 4;

            Zoom.scale = BitConverter.ToSingle(data, position);
            position += 4;

            int numOfNodes = BitConverter.ToInt32(data, position);
            position += 4;
            
            if (numOfNodes > 0)
            {
                string[] ids = new string[numOfNodes];
                Vector3[] positions = new Vector3[numOfNodes];

                for (int i = 0; i < numOfNodes; i++)
                {
                    byte length = data[position];
                    position++;

                    for (int j = 0; j < length; j++)
                        ids[i] += (char)data[position + j];
                    position += length;

                    positions[i] = new Vector3(
                        BitConverter.ToSingle(data, position),
                        BitConverter.ToSingle(data, position + 4),
                        0);
                    position += 8;
                }

                _nodeUIManager.Load(ids, positions);

                ids = null;
                positions = null;
            }
        }
    }
}
