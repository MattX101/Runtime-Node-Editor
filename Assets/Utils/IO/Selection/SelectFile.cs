using System;
using SFB;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.Utils.IO.Selection
{
    [Serializable]
    public class SelectFile : IOSelection
    {
        [SerializeField]
        private TMP_Text _text;

        public void Select()
        {
            ExtensionFilter[] filters = new[]
            {
                new ExtensionFilter("All", "*"),
                new ExtensionFilter("Text", "txt")
            };

            _text.text = SelectFile(filters);
        }
    }
}
