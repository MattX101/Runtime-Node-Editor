using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.Utils.IO.Selection
{
    public class SelectFolder : IOSelection
    {
        [SerializeField]
        private TMP_Text _text;

        public SelectFolder() : base(Paths.GetPath(Paths.Desktop), false)
        {
            //
        }

        public void Select()
        {
            _text.text = SelectFolder();
        }
    }
}