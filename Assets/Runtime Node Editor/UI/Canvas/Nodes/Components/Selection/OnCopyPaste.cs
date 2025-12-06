using RuntimeNodeEditor.Node.Connection.Lines;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        private static bool _currentCopyIsCut;

        private static NodeUI _copiedNodeUI;
        private static bool CopiedNodeIsNull
        {
            get
            {
                return _copiedNodeUI == null;
            }
        }

        private static void Copy(bool cut)
        {
            if (SelectionData.ActiveNodeUIIsNull)
                return;

            _copiedNodeUI = SelectionData.currentActiveNodeUI;
            _currentCopyIsCut = cut;
        }

        private static void Paste(NodeUIManager nodeUIManager, ConnectionLines connectionLines)
        {
            if (CopiedNodeIsNull)
                return;

            Deselect();
            DeselectCopiedNode();

            NodeUI nodeUI = nodeUIManager.FactoryManager.ReturnSpawnUI(_copiedNodeUI);

            connectionLines.Paste(_copiedNodeUI.Node, nodeUI.Node);

            if (_currentCopyIsCut)
            {
                Delete(_copiedNodeUI, true);
                SelectionData.currentActiveNodeUI = nodeUI;
                Copy(false);
            }
        }
    }
}
