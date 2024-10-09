using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Pointer
{
    internal class UIPointer : MonoBehaviour
    {
        public string nodeTitle;
        public TextMeshPro header;

        private void OnMouseOver()
        {
            header.text = gameObject.name;
            header.fontStyle = FontStyles.Normal;
        }

        private void OnMouseExit()
        {
            header.text = nodeTitle;
            header.fontStyle = FontStyles.Bold;
        }
    }
}
