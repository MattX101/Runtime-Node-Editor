using UnityEngine;
using UnityEngine.UI;
using Utils.Colour;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public class UIPointer : MonoBehaviour
    {
        private string _nodeTitle;
        private TextMeshPro _header;

        private RawImage _image;
        private Color _color;

        public void Init(string title, TextMeshPro text, RawImage image, Color color)
        {
            _nodeTitle = title;
            _header = text;
            _image = image;
            _color = color;
        }

        private void OnMouseOver()
        {
            _header.text = gameObject.name;
            _header.fontStyle = FontStyles.Normal;

            Vector3 hsl = ColourConversion.RGBToHSL(_color);
            _image.color = ColourConversion.HSLToRGB(hsl.x, hsl.y * 0.75f, hsl.z * 1.5f);
        }

        private void OnMouseExit()
        {
            _header.text = _nodeTitle;
            _header.fontStyle = FontStyles.Bold;

            _image.color = _color;
        }
    }
}
