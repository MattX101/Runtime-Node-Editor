using RuntimeNodeEditor.Input;
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
            SaveDirectory = _iOSelection.SelectSingleFile(SaveExtension);
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

            Node.Node[] nodes = _nodesObject.GetComponentsInChildren<Node.Node>();
            if (nodes != null)
            {
                writer.Write(nodes == null ? 0 : nodes.Length);

                Node.Save.OnSave.Save(writer, nodes);
                UI.Canvas.Node.Save.OnSave.Save(writer, nodes);
            }

            writer.Close();
        }
    }
}
