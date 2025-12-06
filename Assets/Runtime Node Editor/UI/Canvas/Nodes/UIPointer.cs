using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    internal class UIPointer : MonoBehaviour
    {
        private string _nodeTitle;

        [SerializeField]
        private TMP_Text _header;

        [SerializeField]
        private Image _image;
        private Color _color;

        private void Awake()
        {
            _color = _image.color;
        }

        private void Start()
        {
            if (_header)
            {
                _nodeTitle = _header.text;
            }
        }

        private void OnMouseEnter()
        {
            if (_header)
            {
                _header.text = gameObject.name;
                _header.fontStyle = FontStyles.Normal;
            }

            _image.color = _color * new Color(0.75f, 0.75f, 0.75f, 1.0f);
        }

        private void OnMouseExit()
        {
            if (_header)
            {
                _header.text = _nodeTitle;
                _header.fontStyle = FontStyles.Bold;
            }

            _image.color = _color;
        }
    }
}
