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

        [SerializeField]
        private RuntimeNodeEditor.Node.Node _node;
        public RuntimeNodeEditor.Node.Node Node => _node;

        [Space]

        [SerializeField]
        private RectTransform _rectTransform;
        public Vector3 RootPosition
        {
            get => _rectTransform.localPosition;
            set => _rectTransform.localPosition = value;
        }

        [SerializeField]
        private Image _rootImage;
        private Color _primaryColor;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        [Space]

        [SerializeField]
        private TMP_Text _titleText;

        private void Awake()
        {
            _titleText.text = _nodeTitle;
            _primaryColor = _rootImage.color;
            
            NodeUIDictionary.NodesUI.Add(this.GetHashCode(), this);
        }

        private void OnDestroy()
        {
            NodeUIDictionary.NodesUI.Remove(this.GetHashCode());
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
