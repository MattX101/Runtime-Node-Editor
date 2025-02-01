using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.UI.Canvas.Node.Save;
using Utils.IO;
using Utils.IO.Serialization;
using UnityEngine;

namespace RuntimeNodeEditor.Save
{
    internal partial class SaveSystem : MonoBehaviour
    {
        private readonly IOSelection _iOSelection = new();
        private string _saveDirectory;

        [Header("Nodes")]
        [SerializeField]
        private GameObject _nodesObject;

        private const string SaveExtension = "data";

        public void Save()
        {
            if (_saveDirectory == null)
            {
                SaveAs();
            }

            WriteData();
        }

        public void SaveAs()
        {
            _saveDirectory = _iOSelection.SelectSavePath("Save", SaveExtension);

            WriteData();
        }

        private void WriteData()
        {
            FileWriter writer = new FileWriter(_saveDirectory);

            Zoom.Save(writer);
            Pan.Save(writer);
            OnSave.Save(writer, _nodesObject);

            writer.Close();
        }
    }
}
