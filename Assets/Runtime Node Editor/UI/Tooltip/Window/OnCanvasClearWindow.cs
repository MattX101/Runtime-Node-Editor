namespace RuntimeNodeEditor.UI.Tooltip.Window
{
    public class OnCanvasClearWindow : Window
    {
        private Canvas.CanvasManager canvasManager;
        private Canvas.Node.NodeUIManager nodeUIManager;

        private void Awake()
        {
            canvasManager = FindObjectOfType<Canvas.CanvasManager>();
            nodeUIManager = FindObjectOfType<Canvas.Node.NodeUIManager>();
        }

        public void Clear()
        {
            if (canvasManager == null)
                canvasManager = FindObjectOfType<Canvas.CanvasManager>();
            canvasManager.Reset();

            if (nodeUIManager == null)
                nodeUIManager = FindObjectOfType<Canvas.Node.NodeUIManager>();
            nodeUIManager.Reset();
        }

        public void ClearCanvas()
        {
            Clear();
            Close();
        }
    }
}
