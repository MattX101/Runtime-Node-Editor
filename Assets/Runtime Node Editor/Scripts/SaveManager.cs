using RuntimeNodeEditor.Functions.Seed;
using RuntimeNodeEditor.UI.Canvas;
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

            byte[] data = File.ReadAllBytes(path);

            _seedManager.seed = BitConverter.ToInt32(data, 0);
            Zoom.scale = BitConverter.ToSingle(data, 4);
        }
    }
}
