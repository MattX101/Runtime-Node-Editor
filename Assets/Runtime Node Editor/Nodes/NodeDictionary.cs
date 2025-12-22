using System.Collections.Generic;

namespace RuntimeNodeEditor.Node
{
    public static class NodeDictionary
    {
        private static Dictionary<int, Node> _nodes = new();
        public static Dictionary<int, Node> Nodes => _nodes;
    }
}
