using SFB;
using UnityEngine;

namespace RuntimeNodeEditor.Utils.IO.Selection
{
    public class IOSelection : MonoBehaviour
    {
        private readonly string _startDirectory = Paths.GetPath(Paths.Desktop);

        private readonly bool _multiSelect = false;

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
    }
}