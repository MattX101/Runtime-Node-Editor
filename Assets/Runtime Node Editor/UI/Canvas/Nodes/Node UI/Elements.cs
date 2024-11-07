using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.UI.Canvas.Node.UI;
using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public partial class NodeUI
    {
        // Header
        private GameObject _header;
        private RectTransform _headerRect;
        private TextMeshPro _titleText;

        // Body
        private GameObject _body;
        private RectTransform _bodyRect;

        private float _bodyHeight;
        private Vector2 _bodySize;

        private GameObject _inputs, _outputs;

        private void AddHeader(Color headerHSL, string text)
        {
            Vector3 headerPos = new Vector3(0, (_rootRect.sizeDelta.y - (_sizeY + _borderX2)) / 2, 0);

            _header = UIElement.Create(
                RootObject.transform,
                "Header",
                _rootSize,
                headerPos);
            _headerRect = _header.GetComponent<RectTransform>();
            UIImage.Create(_header, headerHSL);

            // Title Text element
            string title = "Title TMP_Text";

            Vector2 title_textsize = _headerRect.sizeDelta - (Vector2.one * _borderX2);
            Vector3 titleTextPos = new Vector3(0, 0, -1);

            _titleText = UIText.CreateText(
                _header.transform,
                title,
                title_textsize,
                titleTextPos,
                text,
                Color.black);

            UIText.SetFontStyle(_titleText, FontStyles.Bold);
            UIText.SetFontAlignment(_titleText, TextAlignmentOptions.Center);
        }

        private void AddBody()
        {
            _bodySize = new Vector2(_sizeX, _rootRect.sizeDelta.y - GlobalData.HeaderHeight - GlobalData.BorderSize);
            Vector3 bodyPos = new Vector3(0, (-GlobalData.HeaderHeight + GlobalData.BorderSize) / 2, 0);

            _body = UIElement.Create(
                RootObject.transform,
                "Body",
                _bodySize,
                bodyPos);
            _bodyRect = _body.GetComponent<RectTransform>();

            // Pointer Elements
            _inputs = UIElement.Create(
                _body.transform,
                "Inputs",
                _bodySize,
                bodyPos);
            _outputs = UIElement.Create(
                _body.transform,
                "Outputs",
                _bodySize,
                bodyPos);

            _inputs.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, -1);
            _outputs.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, -1);

            if (TogglePreviewImage)
            {
                AddPreviewImage();
            }
        }
    }
}