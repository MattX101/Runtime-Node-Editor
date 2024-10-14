using RuntimeNodeEditor.UI.Canvas.Nodes.Pointer;
using Utils.Colour;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public partial class NodeUI : MonoBehaviour
    {
        internal string NodeId { get; private set; } = "NodeUI";

        // In/Out Pointers
        protected int NumOfLayers = 0, NumOfInputs = 0, NumOfOutputs = 0;

        private float _borderX2;
        private float _sizeX, _sizeY;

        public virtual void Init(string nodeId) { }
        protected void InitBase(string nodeId)
        {
            NodeId = nodeId;

            root = gameObject;
        }

        protected void CreateNodeUI(RuntimeNodeEditor.Nodes.Node.Node node, Color primaryColour, string title)
        {
            int count = NumOfInputs > NumOfOutputs ? NumOfInputs : NumOfOutputs;
            count += NumOfLayers;
            _bodyHeight = count * UISettings.PointerSize;
            _bodyHeight += (count - 1) * UISettings.PointerPadding;
            _bodyHeight += UISettings.BorderSize;

            // Colors
            Vector3 primaryHSL = ColourConversion.RGBToHSL(primaryColour);
            SetRootColor(primaryHSL);

            // Root element
            root.transform.SetParent(UISettings.NodeSpawnTransform);
            _rootImage = root.AddComponent<RawImage>();
            SetPrimaryColor();
            _canvasGroup = root.AddComponent<CanvasGroup>();

            rootRect = root.GetComponent<RectTransform>();

            rootRect.sizeDelta = new Vector2(
                UISettings.NodeWidth,
                UISettings.HeaderHeight + _bodyHeight);

            if (togglePreviewImage)
                rootRect.sizeDelta += new Vector2(0, UISettings.PreviewSize);

            _borderX2 = UISettings.BorderSize * 2;
            _sizeX = rootRect.sizeDelta.x - _borderX2;
            _sizeY = UISettings.HeaderHeight - _borderX2;

            _rootSize = new Vector2(_sizeX, _sizeY);

            AddHeader(ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y, primaryHSL.z * 0.75f), title);
            AddBody(ColourConversion.HSLToRGB(primaryHSL.x, primaryHSL.y * 0.5f, primaryHSL.z));

            AddCollision(root);
        }

        private void AddCollision(GameObject gameObject)
        {
            BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.offset = new Vector2(0, (_bodySize.y + UISettings.BorderSize) / 2);
            boxCollider.size = _rootSize;
        }

        protected GameObject CreateLayer(string name, int layer = 0)
        {
            return UILayer.CreateLayer(name, _body.transform, layer);
        }

        protected GameObject CreatePointer(string name, Color color, int layer, bool pointerIsInput = false, bool createText = false)
        {
            GameObject uiPointerObject = UIPointers.CreatePointer(
                name,
                pointerIsInput ? _inputs : _outputs, 
                color,
                UISettings.PointerTexture,
                layer,
                pointerIsInput,
                createText);

            UIPointer uiPointer = uiPointerObject.AddComponent<UIPointer>();
            uiPointer.nodeTitle = _titleText.text;
            uiPointer.header = _titleText;
            uiPointer.image = uiPointerObject.GetComponent<RawImage>();
            uiPointer.color = color;

            return uiPointerObject;
        }
    }
}
