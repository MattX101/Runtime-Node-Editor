using RuntimeNodeEditor.UI.Canvas;

namespace RuntimeNodeEditor.UI.Tooltip.Window
{
    public class OnCanvasClearWindow : Window
    {
        private CanvasManager _canvasManager;
        private Canvas.Node.NodeUIManager _nodeUIManager;

        private void Awake()
        {
            _canvasManager = FindObjectOfType<CanvasManager>();
            _nodeUIManager = FindObjectOfType<Canvas.Node.NodeUIManager>();
        }

        public void Clear()
        {
            if (_canvasManager == null)
            {
                _canvasManager = FindObjectOfType<CanvasManager>();
            }
            _canvasManager.Reset();

            if (_nodeUIManager == null)
            {
                _nodeUIManager = FindObjectOfType<Canvas.Node.NodeUIManager>();
            }
            _nodeUIManager.Reset();
        }

        public void ClearCanvas()
        {
            Clear();
            Close();
        }
    }
}
