using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.Utils.IO.Selection
{
    public class SelectFolder : IOSelection
    {
        [SerializeField]
        private TMP_Text _text;

        public SelectFolder() : base()
        {
            //
        }

        public void Select()
        {
            _text.text = SelectFolder();
        }
    }
}