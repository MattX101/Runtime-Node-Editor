using UnityEngine;
using UnityEngine.UI;
using Utils.Colour;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public class UIPointer : MonoBehaviour
    {
        public string nodeTitle;
        public TextMeshPro header;

        public RawImage image;
        public Color color;

        private void OnMouseOver()
        {
            header.text = gameObject.name;
            header.fontStyle = FontStyles.Normal;

            Vector3 hsl = ColourConversion.RGBToHSL(color);
            image.color = ColourConversion.HSLToRGB(hsl.x, hsl.y * 0.75f, hsl.z * 1.5f);
        }

        private void OnMouseExit()
        {
            header.text = nodeTitle;
            header.fontStyle = FontStyles.Bold;

            image.color = color;
        }
    }
}
