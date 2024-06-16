using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class NodeExecution : MonoBehaviour
    {
        public void Execute(Node[] nodes)
        {
            List<Node> endNodes = nodes.Where(node => node.endNode).ToList();

            foreach (Node endNode in endNodes)
                endNode.Execute();
        }
    }
}
