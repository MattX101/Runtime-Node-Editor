using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class NodeExecution : MonoBehaviour
    {
        public void Execute()
        {
            Execute(FindObjectsOfType<Node>());
        }

        public void Execute(Node[] nodes)
        {
            Debug.Log("Executing nodes!");

            foreach (Node node in nodes)
                node.ResetExecution();

            List<Node> endNodes = nodes.Where(node => node.endNode).ToList();
            foreach (Node endNode in endNodes)
                endNode.Execute();
        }
    }
}
