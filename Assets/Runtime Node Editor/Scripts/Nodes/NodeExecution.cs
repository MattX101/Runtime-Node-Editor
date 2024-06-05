using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class NodeExecution : MonoBehaviour
    {
        public void Execute(Node[] nodes)
        {
            List<Node> endNodes = new List<Node>();
            
            foreach (Node node in nodes)
                if (node.endNode)
                    endNodes.Add(node);

            foreach (Node endNode in endNodes)
                endNode.Exectute();
        }
    }
}
