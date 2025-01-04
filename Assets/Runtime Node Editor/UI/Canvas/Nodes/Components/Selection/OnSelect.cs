namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        private static void Select(NodeUI node)
        {
            if (!SelectionData.ActiveNodeUIIsNull)
            {
                SelectionData.currentActiveNodeUI.SetPrimaryColor();
            }

            SelectionData.currentActiveNodeUI = node;
            SelectionData.currentActiveNodeUI.ToggleSelectColor();
        }

        private static void Deselect()
        {
            if (SelectionData.ActiveNodeUIIsNull)
                return;

            SelectionData.currentActiveNodeUI.SetPrimaryColor();
            SelectionData.currentActiveNodeUI = null;
        }

        private static void DeselectCopiedNode()
        {
            if (CopiedNodeIsNull)
                return;

            _copiedNodeUI.SetPrimaryColor();
        }
    }
}
