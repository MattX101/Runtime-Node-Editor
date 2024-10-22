namespace RuntimeNodeEditor.UI.Tooltip.Window
{
    public class OnOpenWindow : Window
    {
        private Canvas.CanvasManager canvasManager;
        private Canvas.Node.NodeUIManager nodeUIManager;

        private void Awake()
        {
            canvasManager = FindObjectOfType<Canvas.CanvasManager>();
            nodeUIManager = FindObjectOfType<Canvas.Node.NodeUIManager>();
        }

        public void ClearCanvas()
        {
            canvasManager.Reset();
            nodeUIManager.Reset();

            Close();
        }
    }
}
