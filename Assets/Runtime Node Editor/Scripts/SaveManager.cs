using RuntimeNodeEditor.Functions.Seed;
using RuntimeNodeEditor.UI.Canvas;
using RuntimeNodeEditor.Utils.IO.Selection;
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
        private SeedManager _seedManager;

        private List<byte> _data = new List<byte>();

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
            _saveDirectory = _iOSelection.SaveFile("Save", "data");

            WriteData();
        }

        public void Load()
        {
            //
        }

        private void WriteData()
        {
            _data.Clear();

            foreach (byte b in _seedManager.Save()) _data.Add(b);
            foreach (byte b in ScreenScale.Save()) _data.Add(b);
            foreach (byte b in Zoom.Save()) _data.Add(b);
            foreach (byte b in Pan.Save()) _data.Add(b);

            File.WriteAllBytes(_saveDirectory, _data.ToArray());
        }

        private void LoadData()
        {
            //
        }
    }
}
