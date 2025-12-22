using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Node;
using Utils.IO;
using Utils.IO.Serialization;
using UnityEngine;

namespace RuntimeNodeEditor.Save
{
    public class SaveSystem : MonoBehaviour
    {
        private readonly IOSelection _iOSelection = new();

        public string SaveDirectory
        {
            get; 
            private set;
        }

        [Header("Nodes")]
        [SerializeField]
        private GameObject _nodesObject;

        private const string SaveExtension = "data";

        public void SelectSaveDirectory()
        {
            SaveDirectory = _iOSelection.SelectFile(SaveExtension);
        }
        
        public void Save()
        {
            if (SaveDirectory == null)
            {
                SaveAs();
            }

            WriteData();
        }

        public void SaveAs()
        {
            SaveDirectory = _iOSelection.SelectSavePath("Save", SaveExtension);

            WriteData();
        }

        private void WriteData()
        {
            FileWriter writer = new FileWriter(SaveDirectory);

            Zoom.Save(writer);
            Pan.Save(writer);

            if (NodeDictionary.Nodes != null)
            {
                writer.Write(NodeDictionary.Nodes == null ? 0 : NodeDictionary.Nodes.Count);

                Node.Save.OnSave.Save(writer);
                UI.Canvas.Node.Save.OnSave.Save(writer);
            }

            writer.Close();
        }
    }
}
