using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.Component;
using RuntimeNodeEditor.UI.Elements;
using RuntimeNodeEditor.UI.Pointer;
using RuntimeNodeEditor.UI.Node.Elements;
using RuntimeNodeEditor.Utils.Colour;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeUI
    {
        public readonly string nodeId = "NodeUI";

        // Root
        public GameObject root;
        public RectTransform rootRect;

        private Vector2 _rootSize;

        private CanvasGroup _canvasGroup;

        private RawImage _rootImage;
        private Color _primaryColor;

        // Header
        private GameObject _header;
        private RectTransform _headerRect;
        private TextMeshPro _titleText;

        // Body
        private GameObject _body;
        private RectTransform _bodyRect;

        private float _bodyHeight;
        private Vector2 _bodySize;

        public bool drawBodyImage = true;

        private GameObject _inputs;
        private GameObject _outputs;

        private GameObject _previewImageObject;
        //public RawImage previewRawImage;
        public ImagePreview imagePreview;

        // In/Out Pointers
        protected int numOfInputs, numOfOutputs;

        public InputPointer[] inputs;
        public OutputPointer[] outputs;

        protected UIPointers uIPointers;

        // Input Field
        public bool toggleInputField = false;

        //public TMP_InputField inputField = null;

        // Boolean Preview
        //public Button button = null;

        // Other
        public bool togglePreviewImage = false;
        public bool interactablePreview = false;

        public bool isInput = false;

        private float _borderX2;
        private float _sizeX, _sizeY;

        // Elements
        public NodeUIElements elements;

        public NodeUI()
        {
            //
        }

        public NodeUI(string nodeId)
        {
            this.nodeId = nodeId;
        }

        public void CreateRoot(string title)
        {
            root = UIElement.Create(UISettings.nodeCanvasTransform, title, Vector2.one, Vector3.zero);
        }

        public void CreateNodeUI(RuntimeNodeEditor.Node.Node node, Color primaryColour, string title)
        {
            uIPointers = new UIPointers(node);

            int count = numOfInputs > numOfOutputs ? numOfInputs : numOfOutputs;
            _bodyHeight = count * UISettings.pointerSize;
            _bodyHeight += (count - 1) * UISettings.pointerPadding;
            _bodyHeight += UISettings.borderSize;

            // Colours
            Vector3 primaryHSL = ColourConversion.RGBToHSL(primaryColour);
            _primaryColor = ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y, primaryHSL.z * 0.5f);

            // Root element
            root.transform.SetParent(UISettings.nodeCanvasTransform);
            _rootImage = root.AddComponent<RawImage>();
            SetPrimaryColor();
            _canvasGroup = root.AddComponent<CanvasGroup>();

            rootRect = root.GetComponent<RectTransform>();

            rootRect.sizeDelta = new Vector2(
                UISettings.nodeWidth,
                UISettings.headerHeight + _bodyHeight);

            if (togglePreviewImage) 
                rootRect.sizeDelta = new Vector2(rootRect.sizeDelta.x, rootRect.sizeDelta.y + UISettings.previewSize);

            _borderX2 = UISettings.borderSize * 2;
            _sizeX = rootRect.sizeDelta.x - _borderX2;
            _sizeY = UISettings.headerHeight - _borderX2;

            _rootSize = new Vector2(_sizeX, _sizeY);

            AddHeader(
                ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y, primaryHSL.z * 0.75f), 
                title);
            AddBody(
                ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y * 0.5f, primaryHSL.z));

            AddCollision(root);
        }

        private void AddHeader(Color headerHSL, string text)
        {
            Vector3 headerPos = new Vector3(0, (rootRect.sizeDelta.y - (_sizeY + _borderX2)) / 2, 0);

            _header = UIElement.Create(
                root.transform,
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
                text);
            
            UIText.SetFontStyle(_titleText, FontStyles.Bold);
            UIText.SetFontAligment(_titleText, TextAlignmentOptions.Center);
        }

        private void AddBody(Color bodyHSL)
        {
            _bodySize = new Vector2(_sizeX, rootRect.sizeDelta.y - UISettings.headerHeight - UISettings.borderSize);
            Vector3 bodyPos = new Vector3(0, (-UISettings.headerHeight + UISettings.borderSize) / 2, 0);

            _body = UIElement.Create(
                root.transform,
                "Body",
                _bodySize,
                bodyPos);
            _bodyRect = _body.GetComponent<RectTransform>();

            if (drawBodyImage)
                UIImage.Create(_body, bodyHSL);

            // Pointer elements
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

            if (togglePreviewImage)
                AddPreviewImage();
        }

        private void AddCollision(GameObject gameObject)
        {
            BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.offset = new Vector2(0, (_bodySize.y + UISettings.borderSize) / 2);
            boxCollider.size = _rootSize;
        }

        private void AddPreviewImage()
        {
            if (!togglePreviewImage)
                return;

            float size = UISettings.previewSize - UISettings.previewImageMargin;

            Vector2 previewImageSize = new Vector2(size, size);
            float posY = (rootRect.sizeDelta.y - size - UISettings.previewImageMargin) / 2 - UISettings.headerHeight - _bodyHeight;
            Vector3 previewImagePos = new Vector3(0.0f, posY, 0.0f);

            _previewImageObject = UIElement.Create(
                root.transform,
                "Preview",
                previewImageSize,
                previewImagePos);

            imagePreview = new ImagePreview();
            imagePreview.image = UIImage.Create(_previewImageObject, Color.black);
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

        protected GameObject CreatePointer(string name, ValueType valueType, int i, bool createText, bool pointerIsInput)
        {
            return uIPointers.CreatePointer(
                name,
                pointerIsInput ? _inputs : _outputs, 
                valueType, 
                i, 
                createText,
                pointerIsInput);
        }

        protected TMP_InputField AddInputField(Transform parent, TMP_InputField.ContentType contentType, int i, bool pointerIsInput, bool interactable)
        {
            return uIPointers.AddInputField(
                parent, 
                contentType, 
                i, 
                pointerIsInput, 
                interactable);
        }

        protected BooleanButton AddBooleanPreview(Transform parent, bool pointerIsInput)
        {
            return uIPointers.AddBooleanPreview(parent, pointerIsInput);
        }

        protected Slider AddSlider(Transform parent, bool pointerIsInput)
        {
            return uIPointers.AddSlider(parent, pointerIsInput);
        }

        protected void PreviewColor(int a, int b, int c, bool pointersAreInput)
        {
            if (!togglePreviewImage)
                return;

            if (imagePreview == null)
                AddPreviewImage();

            if (pointersAreInput)
                imagePreview.SetSliderInput(
                    inputs[a].gameObject.GetComponentInChildren<Slider>(),
                    inputs[b].gameObject.GetComponentInChildren<Slider>(),
                    inputs[c].gameObject.GetComponentInChildren<Slider>());
            else
                imagePreview.SetSliderInput(
                    outputs[a].gameObject.GetComponentInChildren<Slider>(),
                    outputs[b].gameObject.GetComponentInChildren<Slider>(),
                    outputs[c].gameObject.GetComponentInChildren<Slider>());
        }

        public void ToggleSelectColor()
        {
            _rootImage.color = _primaryColor * new Color(0.5f, 0.5f, 0.5f);
        }
        public void SetPrimaryColor()
        {
            _rootImage.color = _primaryColor;
        }

        public void SetAlpha(float alpha)
        {
            _canvasGroup.alpha = alpha;
        }

        public void BlockRaycasts(bool toggle)
        {
            _canvasGroup.blocksRaycasts = toggle;
        }

        public byte[] Save()
        {
            return elements.Save(nodeId, rootRect.localPosition);
        }
    }
}
