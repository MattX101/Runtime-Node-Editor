using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.Utils.Colour;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.RuntimeNode.UI
{
    public class NodeUI
    {
        private float _bodyHeight;

        public GameObject root;
        public RectTransform rootRect;

        private GameObject _header;
        private RectTransform _headerRect;
        private TextMeshPro _titleText;

        private GameObject _body;
        private RectTransform _bodyRect;

        private GameObject _bodyElements;
        private RectTransform _bodyElementsRect;

        private GameObject _inputs;
        private GameObject _outputs;

        private GameObject _previewImageObject;
        public RawImage previewRawImage;

        private UIPointers _uIPointers = new UIPointers();

        public NodeDrag nodeDrag;

        public InputPointer[] inputs;
        public OutputPointer[] outputs;

        public bool togglePreviewImage;

        protected int numOfInputs = 1;
        protected int numOfOutputs = 1;

        public void CreateRoot(string title)
        {
            root = UIElement.CreateUIElement(UISettings.parent, title, Vector2.one, Vector3.zero);
        }

        public void CreateNodeUI(Color primaryColour, string title)
        {
            _bodyHeight = numOfInputs > numOfOutputs ?
                numOfInputs * UISettings.pointerSize + (numOfInputs * (UISettings.pointerSize / 2)) :
                numOfOutputs * UISettings.pointerSize + (numOfOutputs * (UISettings.pointerSize / 2));

            // Colours
            Vector3 primaryHSL = ColourConversion.RGBToHSL(primaryColour);

            Color headerHSL = ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y, primaryHSL.z * 0.75f);
            Color rootHSL = ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y, primaryHSL.z * 0.5f);
            Color bodyHSL = ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y * 0.5f, primaryHSL.z);

            // Root element
            root.transform.SetParent(UISettings.parent.transform);
            RawImage rawImage = root.AddComponent<RawImage>();
            rawImage.color = rootHSL;
            root.AddComponent<CanvasGroup>();

            rootRect = root.GetComponent<RectTransform>();
            rootRect.sizeDelta = togglePreviewImage ?
                new Vector2(UISettings.nodeWidth, UISettings.headerHeight + UISettings.elementSpacing + _bodyHeight + UISettings.elementSpacing + UISettings.previewSize) :
                new Vector2(UISettings.nodeWidth, UISettings.headerHeight + UISettings.elementSpacing + _bodyHeight + UISettings.elementSpacing);

            BoxCollider2D boxCollider = root.AddComponent<BoxCollider2D>();
            boxCollider.size = new Vector2(rootRect.rect.width, rootRect.rect.height);
            nodeDrag = root.AddComponent<NodeDrag>();

            AddHeader(headerHSL, title);

            AddBody(bodyHSL);
        }

        private void AddHeader(Color headerHSL, string title)
        {
            float doubleBorderSize = UISettings.borderSize * 2;

            Vector2 headerSize = new Vector2(rootRect.sizeDelta.x - doubleBorderSize, UISettings.headerHeight - doubleBorderSize);
            Vector3 headerPos = new Vector3(0.0f, (rootRect.sizeDelta.y / 2) - ((headerSize.y + doubleBorderSize) / 2), 0.0f);

            _header = UIElement.CreateUIElement(root.transform, "Header", headerSize, headerPos);
            _headerRect = _header.GetComponent<RectTransform>();
            UIImage.CreateRawImage(_header, headerHSL);

            // Title Text element
            Vector2 titleTextSize = new Vector2(_headerRect.sizeDelta.x - doubleBorderSize, _headerRect.sizeDelta.y - doubleBorderSize);

            _titleText = UIText.CreateText(_header.transform, "Title TMP_Text", titleTextSize, new Vector3(0.0f, 0.0f, -1.0f), title);
            _titleText.alignment = TextAlignmentOptions.Center;
            _titleText.fontStyle = FontStyles.Bold;
        }

        private void AddBody(Color bodyHSL)
        {
            float doubleBorderSize = UISettings.borderSize * 2;

            Vector2 bodySize = new Vector2(rootRect.sizeDelta.x - doubleBorderSize, rootRect.sizeDelta.y - UISettings.headerHeight - (doubleBorderSize / 2));
            Vector3 bodyPos = new Vector3(0.0f, (-UISettings.headerHeight / 2) + (doubleBorderSize / 4), 0.0f);

            _body = UIElement.CreateUIElement(root.transform, "Body", bodySize, bodyPos);
            _bodyRect = _body.GetComponent<RectTransform>();
            UIImage.CreateRawImage(_body, bodyHSL);

            // Body elements
            Vector2 bodyElementsSize = new Vector2(rootRect.sizeDelta.x, _bodyHeight);
            Vector3 bodyElementsPos = new Vector3(0.0f, (rootRect.sizeDelta.y / 2) - (bodyElementsSize.y / 2) - UISettings.headerHeight - UISettings.elementSpacing, 0.0f);

            _bodyElements = UIElement.CreateUIElement(root.transform, "Body Elements", bodyElementsSize, bodyElementsPos);
            _bodyElements.transform.SetParent(_body.transform);
            _bodyElementsRect = _bodyElements.GetComponent<RectTransform>();

            // Pointer elements
            _inputs = UIElement.CreateUIElement(_bodyElements.transform, "Inputs", bodyElementsSize, bodyElementsPos);
            _inputs.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, -1);
            _outputs = UIElement.CreateUIElement(_bodyElements.transform, "Outputs", bodyElementsSize, bodyElementsPos);
            _outputs.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, -1);

            AddPreviewImage();
        }

        private void AddPreviewImage()
        {
            if (togglePreviewImage)
            {
                Vector2 previewImageSize = new Vector2(UISettings.previewSize - UISettings.previewImageMargin, UISettings.previewSize - UISettings.previewImageMargin);
                float posY = (rootRect.sizeDelta.y / 2) - (previewImageSize.y / 2) - UISettings.headerHeight - UISettings.elementSpacing - _bodyHeight - UISettings.elementSpacing - (UISettings.previewImageMargin / 2);
                Vector3 previewImagePos = new Vector3(0.0f, posY, 0.0f);

                _previewImageObject = UIElement.CreateUIElement(root.transform, "Preview", previewImageSize, previewImagePos);
                previewRawImage = UIImage.CreateRawImage(_previewImageObject, Color.white);

                int res = 128;
                float scale = 100.0f;
                float offset = GetHashCode() / 1000.0f;
                Color[] colourMap = new Color[res * res];
                for (int x = 0; x < res; x++)
                {
                    for (int y = 0; y < res; y++)
                    {
                        colourMap[y * res + x] = Color.Lerp(Color.black, Color.white, Mathf.PerlinNoise((x + offset) / scale, (y + offset) / scale));
                    }
                }
                Texture2D previewImage = new Texture2D(res, res);
                previewImage.SetPixels(colourMap);
                previewImage.filterMode = FilterMode.Point;
                previewImage.Apply();

                previewRawImage.texture = previewImage;
            }
        }

        /*public void UpdateNodeUI(float scale, float previewImageScale)
        {
            rootRect.localScale = new Vector3(scale, scale, scale);

            if (togglePreviewImage)
            {
                float updatedNodeWidth = UISettings.nodeWidth * previewImageScale;
                float updatedPreviewImageSize = updatedNodeWidth;

                RectTransform updatedRect = rootRect;
                updatedRect.sizeDelta = new Vector2(updatedNodeWidth, UISettings.headerHeight + UISettings.elementSpacing + _bodyHeight + UISettings.elementSpacing + updatedPreviewImageSize);

                Vector2 previewImageSize = new Vector2(updatedNodeWidth - UISettings.previewImageMargin, updatedNodeWidth - UISettings.previewImageMargin);
                float posY = (updatedRect.sizeDelta.y / 2) - (previewImageSize.y / 2) - UISettings.headerHeight - UISettings.elementSpacing - _bodyHeight - UISettings.elementSpacing - (UISettings.previewImageMargin / 2);
                Vector3 previewImagePos = new Vector3(0.0f, posY, 0.0f);

                UIImage.TogglePreviewImage(false, _previewImageObject);

                RectTransform updatedBodyRect = _bodyRect;
                updatedBodyRect.sizeDelta = new Vector2(updatedNodeWidth, _bodyHeight);

                UpdateElements(updatedRect, updatedBodyRect);
                UIElement.UpdateUIElement(_previewImageObject.GetComponent<RectTransform>(), previewImageSize, previewImagePos);
            }
            else
            {
                UIImage.TogglePreviewImage(true, _previewImageObject);

                RectTransform updatedBodyRect = rootRect;
                updatedBodyRect.sizeDelta = new Vector2(UISettings.nodeWidth, UISettings.headerHeight + UISettings.elementSpacing + _bodyHeight + UISettings.elementSpacing);

                UpdateElements(updatedBodyRect, _bodyRect);
            }
        }

        private void UpdateElements(RectTransform rect, RectTransform pointerRect)
        {
            Vector2 headerSize = new Vector2(rect.sizeDelta.x, UISettings.headerHeight);
            Vector3 headerPos = new Vector3(0.0f, (rect.sizeDelta.y / 2) - (headerSize.y / 2), 0.0f);
            UIElement.UpdateUIElement(_headerRect, headerSize, headerPos);

            Vector2 bodySize = new Vector2(rect.sizeDelta.x, _bodyHeight);
            Vector3 bodyPos = new Vector3(0.0f, (rect.sizeDelta.y / 2) - (bodySize.y / 2) - UISettings.headerHeight - UISettings.elementSpacing, 0.0f);
            UIElement.UpdateUIElement(_bodyRect, bodySize, bodyPos);

            _uIPointers.UpdateUIPointers(pointerRect, true);
            _uIPointers.UpdateUIPointers(pointerRect, false);
        }*/

        public GameObject CreateInputPointer(string name, ValueType valueType, int i)
        {
            return _uIPointers.CreateInputPointer(name, _inputs, valueType, i);
        }
        public GameObject CreateOutputPointer(string name, ValueType valueType, int i)
        {
            return _uIPointers.CreateOutputPointer(name, _outputs, valueType, i);
        }
    }
}
