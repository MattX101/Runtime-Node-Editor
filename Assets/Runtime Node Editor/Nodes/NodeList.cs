using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public static class NodeList
    {
        private static Dictionary<int, Node> _nodes = new Dictionary<int, Node>();
        internal static Dictionary<int, Node> Nodes => _nodes;

        public static void Add(int code, Node node)
        {
            Debug.Log("Added: " + code + " to list");
            _nodes.Add(code, node);
        }

        public static void Remove(int code, Node node)
        {
            Debug.Log("Removed: " + code + " from the list");
            _nodes.Remove(code);
        }
    }
}
