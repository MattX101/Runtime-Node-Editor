using Utils.IO.Serialization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class NodeUI : MonoBehaviour
    {
        [SerializeField]
        private string _nodeTitle = "NodeUI";

        private RectTransform _rectTransform;
        public Vector3 RootPosition
        {
            get => _rectTransform.localPosition;
            set => _rectTransform.localPosition = value;
        }

        private Image _rootImage;
        private Color _primaryColor;

        [SerializeField]
        private TMP_Text _titleText;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _titleText.text = _nodeTitle;

            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();

            _rootImage = GetComponent<Image>();
            _primaryColor = _rootImage.color;
        }

        private void OnMouseDown()
        {
            SetAlpha(0.5f);
        }

        private void OnMouseUp()
        {
            SetAlpha();
        }

        private void OnMouseEnter()
        {
            SetAlpha(0.75f);
        }

        private void OnMouseExit()
        {
            SetAlpha();
        }

        internal void ToggleSelectColor()
        {
            _rootImage.color = _primaryColor * new Color(0.5f, 0.5f, 0.5f);
        }
        internal void SetPrimaryColor()
        {
            _rootImage.color = _primaryColor;
        }

        internal void SetAlpha(float alpha = 1.0f)
        {
            _canvasGroup.alpha = alpha;
        }

        internal void SaveNodeUI(FileWriter writer)
        {
            // Node Position
            writer.Write(_rectTransform.localPosition.x);
            writer.Write(_rectTransform.localPosition.y);
        }
    }
}
