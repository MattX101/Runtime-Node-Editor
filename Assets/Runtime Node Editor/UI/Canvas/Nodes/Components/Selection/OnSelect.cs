namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        private static void Select(RuntimeNodeEditor.Node.Node node)
        {
            if (!CurrentNodeIsNull)
            {
                _currentNode.GetComponent<NodeUI>().SetPrimaryColor();
            }

            _currentNode = node;
            _currentNode.GetComponent<NodeUI>().ToggleSelectColor();
        }

        private static void Deselect()
        {
            if (CurrentNodeIsNull)
                return;
            
            _currentNode.GetComponent<NodeUI>().SetPrimaryColor();
            _currentNode = null;
        }
    }
}
