using SFB;
using UnityEngine;

namespace RuntimeNodeEditor.Utils.IO.Selection
{
    public class IOSelection
    {
        private readonly static string _defualtDirectory = Paths.GetPath(Paths.Desktop);
        private readonly string _startDirectory;

        private readonly bool _multiSelect = false;

        public IOSelection() : this(_defualtDirectory, false) { }

        public IOSelection(string startDirectory) : this(startDirectory, false) { }

        public IOSelection(string startDirectory, bool multiSelect)
        {
            _startDirectory = startDirectory;
            _multiSelect = multiSelect;
        }

        public string SelectFile(ExtensionFilter[] extensions)
        {
            if (extensions == null)
            {
                extensions = new ExtensionFilter[1] 
                { 
                    new ExtensionFilter("All Files", "*")
                };
            }
            
            string[] paths = StandaloneFileBrowser.OpenFilePanel(
                "Select File",
                _startDirectory,
                extensions,
                _multiSelect);

            return GetPath(paths);
        }

        public string SelectFolder()
        {
            string[] paths = StandaloneFileBrowser.OpenFolderPanel(
                "Select Folder",
                _startDirectory,
                _multiSelect);

            return GetPath(paths);
        }

        private string GetPath(string[] paths)
        {
            if (paths.Length > 0)
            {
                string path = paths[0];
                Debug.Log(path);

                return path;
            }
            else
            {
                Debug.LogWarning("No valid path was selected!");

                return null;
            }
        }

        public string SaveFile(string defualtFileName, string filter)
        {
            return StandaloneFileBrowser.SaveFilePanel(
                "Save As",
                _defualtDirectory,
                defualtFileName,
                filter);
        }
        public string SaveFile(string defualtFileName, ExtensionFilter[] filters)
        {
            return StandaloneFileBrowser.SaveFilePanel(
                "Save As",
                _defualtDirectory,
                defualtFileName,
                filters);
        }
    }
}