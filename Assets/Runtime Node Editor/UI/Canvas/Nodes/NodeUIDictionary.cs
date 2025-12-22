using System.Collections.Generic;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public static class NodeUIDictionary
    {
        private static Dictionary<int, NodeUI> _nodesUI = new();
        public static Dictionary<int, NodeUI> NodesUI => _nodesUI;
    }
}
