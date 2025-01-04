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

            RuntimeNodeEditor.Node.Node copiedNode = _copiedNodeUI.GetComponent<RuntimeNodeEditor.Node.Node>();
            RuntimeNodeEditor.Node.Node newNode = nodeUI.GetComponent<RuntimeNodeEditor.Node.Node>();

            if (newNode.Elements != null)
            {
                newNode.Elements.SetElements(copiedNode.Elements);
            }

            connectionLines.Paste(copiedNode, newNode);

            if (_currentCopyIsCut)
            {
                Delete(_copiedNodeUI, true);
                SelectionData.currentActiveNodeUI = nodeUI;
                Copy(false);
            }
        }
    }
}
