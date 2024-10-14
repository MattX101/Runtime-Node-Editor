using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RuntimeNodeEditor.Node.Lines;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Components
{
    internal static partial class Selection
    {
        private static bool _currentCopyIsCut;

        private static RuntimeNodeEditor.Node.Node.Node _copiedNode;
        private static bool CopiedNodeIsNull
        {
            get
            {
                return _copiedNode == null;
            }
        }

        private static void Copy(bool cut)
        {
            if (CurrentNodeIsNull)
                return;

            _copiedNode = _currentNode;
            _currentCopyIsCut = cut;
        }

        private static void Paste(NodeUIManager nodeUIManager, ConnectionLines connectionLines)
        {
            /*if (CopiedNodeIsNull)
                return;

            NodeUI copiedNodeUI = _copiedNode.GetComponent<NodeUI>();
            NodeUI newNodeUI = nodeUIManager.SpawnWithReturn(copiedNodeUI.NodeId, copiedNodeUI.RootPosition);

            RuntimeNodeEditor.Node.Node.Node newNode = newNodeUI.root.GetComponent<RuntimeNodeEditor.Node.Node.Node>();

            if (newNode.Elements != null)
                newNode.Elements.SetElements(_copiedNode.Elements);
            
            connectionLines.Paste(_copiedNode, newNode);

            if (_currentCopyIsCut)
            {
                Delete(_copiedNode);
                _currentNode = newNode;
                Copy(false);
            }*/
        }
    }
}
