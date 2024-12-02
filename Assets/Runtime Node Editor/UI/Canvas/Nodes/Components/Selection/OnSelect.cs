namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        private static void Select(NodeUI node)
        {
            if (!CurrentNodeIsNull)
            {
                _currentNode.SetPrimaryColor();
            }

            _currentNode = node;
            _currentNode.ToggleSelectColor();
        }

        private static void Deselect()
        {
            if (CurrentNodeIsNull)
                return;
            
            _currentNode.SetPrimaryColor();
            _currentNode = null;
        }

        private static void DeselectCopiedNode()
        {
            if (CopiedNodeIsNull)
                return;

            _copiedNodeUI.SetPrimaryColor();
        }
    }
}
