using RuntimeNodeEditor.Data;
using UnityEngine;
using UnityEngine.UI;
using Utils.Colour;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public partial class NodeUI
    {
        // Root
        protected internal GameObject RootObject;

        private RectTransform _rootRect;
        public Vector3 RootPosition
        {
            get => _rootRect.localPosition; 
            set => _rootRect.localPosition = value; 
        }

        private Vector2 _rootSize;

        private RawImage _rootImage;
        private Color _primaryColor;

        private CanvasGroup _canvasGroup;

        protected void PopulateRoot(string title)
        {
            RootObject.name = title;
            RootObject.transform.parent = GlobalData.NodeSpawnTransform.transform;
            
            RectTransform rect = RootObject.AddComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.sizeDelta = Vector2.one;
            rect.localPosition = Vector3.zero;
        }

        private void SetRootColor(Vector3 hsl)
        {
            _primaryColor = ColourConversion.HSLToRGB(hsl.x, hsl.y, hsl.z * 0.5f);
        }

        internal void ToggleSelectColor()
        {
            _rootImage.color = _primaryColor * new Color(0.5f, 0.5f, 0.5f);
        }
        internal void SetPrimaryColor()
        {
            _rootImage.color = _primaryColor;
        }

        internal void SetAlpha(float alpha)
        {
            _canvasGroup.alpha = alpha;
        }

        internal void BlockRaycasts(bool toggle)
        {
            _canvasGroup.blocksRaycasts = toggle;
        }
    }
}
