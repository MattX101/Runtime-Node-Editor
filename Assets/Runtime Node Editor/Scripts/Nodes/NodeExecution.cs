using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes
{
    public class NodeExecution : MonoBehaviour
    {
        public void Execute()
        {
            Debug.Log("Executing nodes!");

            Node.Node[] nodes = FindObjectsOfType<Node.Node>();
            List<Node.Node> endNodes = nodes.Where(node => node.endNode).ToList();

            foreach (Node.Node endNode in endNodes)
                endNode.Execute();
        }

        public void Execute(Node.Node[] nodes)
        {
            Debug.Log("Executing nodes!");

            List<Node.Node> endNodes = nodes.Where(node => node.endNode).ToList();

            foreach (Node.Node endNode in endNodes)
                endNode.Execute();
        }
    }
}
