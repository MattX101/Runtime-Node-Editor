using System;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.Utils.IO.Selection
{
    [Serializable]
    public class SelectFolder : IOSelection
    {
        [SerializeField]
        private TMP_Text _text;

        public void Select()
        {
            _text.text = SelectFolder();
        }
    }
}