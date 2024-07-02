using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.UI.Elements;
using RuntimeNodeEditor.UI.Canvas.Nodes.Pointer;
using RuntimeNodeEditor.Functions.UI.Component;
using Utils.Colour;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class NodeUI : MonoBehaviour
    {
        public string NodeId { get; private set; } = "NodeUI";

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
        protected ImagePreview ImagePreview;

        // In/Out Pointers
        protected int NumOfInputs = 0, NumOfOutputs = 0;

        private UIPointers _uiPointers;

        // Input Field
        public bool toggleInputField = false;

        // Other
        public bool togglePreviewImage = false;
        public bool interactablePreview = false;

        public bool isInput = false;

        private float _borderX2;
        private float _sizeX, _sizeY;

        public virtual void Init(string nodeId)
        {
            NodeId = nodeId;

            root = gameObject;
        }

        protected void PopulateRoot(string title)
        {
            root.name = title;
            root.transform.parent = UISettings.NodeCanvasTransform.transform;

            RectTransform rect = root.AddComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.sizeDelta = Vector2.one;
            rect.localPosition = Vector3.zero;
        }

        protected void CreateNodeUI(RuntimeNodeEditor.Nodes.Node.Node node, Color primaryColour, string title)
        {
            _uiPointers = new UIPointers(node);

            int count = NumOfInputs > NumOfOutputs ? NumOfInputs : NumOfOutputs;
            _bodyHeight = count * UISettings.PointerSize;
            _bodyHeight += (count - 1) * UISettings.PointerPadding;
            _bodyHeight += UISettings.BorderSize;

            // Colours
            Vector3 primaryHSL = ColourConversion.RGBToHSL(primaryColour);
            _primaryColor = ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y, primaryHSL.z * 0.5f);

            // Root element
            root.transform.SetParent(UISettings.NodeCanvasTransform);
            _rootImage = root.AddComponent<RawImage>();
            SetPrimaryColor();
            _canvasGroup = root.AddComponent<CanvasGroup>();

            rootRect = root.GetComponent<RectTransform>();

            rootRect.sizeDelta = new Vector2(
                UISettings.NodeWidth,
                UISettings.HeaderHeight + _bodyHeight);

            if (togglePreviewImage) 
                rootRect.sizeDelta = new Vector2(rootRect.sizeDelta.x, rootRect.sizeDelta.y + UISettings.PreviewSize);

            _borderX2 = UISettings.BorderSize * 2;
            _sizeX = rootRect.sizeDelta.x - _borderX2;
            _sizeY = UISettings.HeaderHeight - _borderX2;

            _rootSize = new Vector2(_sizeX, _sizeY);

            AddHeader(ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y, primaryHSL.z * 0.75f), title);
            AddBody(ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y * 0.5f, primaryHSL.z));

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
            UIText.SetFontAlignment(_titleText, TextAlignmentOptions.Center);
        }

        private void AddBody(Color bodyHSL)
        {
            _bodySize = new Vector2(_sizeX, rootRect.sizeDelta.y - UISettings.HeaderHeight - UISettings.BorderSize);
            Vector3 bodyPos = new Vector3(0, (-UISettings.HeaderHeight + UISettings.BorderSize) / 2, 0);

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
            boxCollider.offset = new Vector2(0, (_bodySize.y + UISettings.BorderSize) / 2);
            boxCollider.size = _rootSize;
        }

        private void AddPreviewImage()
        {
            if (!togglePreviewImage)
                return;

            float size = UISettings.PreviewSize - UISettings.PreviewImageMargin;

            Vector2 previewImageSize = new Vector2(size, size);
            float posY = (rootRect.sizeDelta.y - size - UISettings.PreviewImageMargin) / 2 - UISettings.HeaderHeight - _bodyHeight;
            Vector3 previewImagePos = new Vector3(0.0f, posY, 0.0f);

            _previewImageObject = UIElement.Create(
                root.transform,
                "Preview",
                previewImageSize,
                previewImagePos);

            ImagePreview = new ImagePreview
            {
                Image = UIImage.Create(_previewImageObject, Color.black)
            };
        }

        protected GameObject CreatePointer(string name, ValueType valueType, int layer, bool pointerIsInput = false, bool createText = false)
        {
            return _uiPointers.CreatePointer(
                name,
                pointerIsInput ? _inputs : _outputs, 
                valueType,
                layer,
                pointerIsInput,
                createText);
        }

        protected TMP_InputField AddInputField(Transform parent, TMP_InputField.ContentType contentType, bool pointerIsInput = false, bool interactable = true, int layer = 0)
        {
            return _uiPointers.AddInputField(
                parent, 
                contentType,
                pointerIsInput,
                interactable,
                layer);
        }

        protected BooleanButton AddBooleanPreview(Transform parent, bool pointerIsInput = false)
        {
            return _uiPointers.AddBooleanPreview(parent, pointerIsInput);
        }

        protected Slider AddSlider(Transform parent, bool pointerIsInput = false)
        {
            return _uiPointers.AddSlider(parent, pointerIsInput);
        }

        protected void PreviewColor(Slider r, Slider g, Slider b)
        {
            if (!togglePreviewImage)
                return;

            if (ImagePreview == null)
                AddPreviewImage();

            ImagePreview.SetSliderInput(r, g, b);
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

        public byte[] SaveNodeUI()
        {
            List<byte> bytes = new()
            {
                // Node ID
                (byte)NodeId.Length
            };

            bytes.AddRange(NodeId.Select(t => (byte)t));

            // Node Position
            bytes.AddRange(System.BitConverter.GetBytes(rootRect.localPosition.x));
            bytes.AddRange(System.BitConverter.GetBytes(rootRect.localPosition.y));

            return bytes.ToArray();
        }
    }
}
