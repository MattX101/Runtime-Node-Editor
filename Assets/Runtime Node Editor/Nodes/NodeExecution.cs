using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class NodeExecution : MonoBehaviour
    {
        [SerializeField]
        private GameObject _nodesParent;

        public void Execute()
        {
            Execute(_nodesParent.GetComponentsInChildren<Node>());
        }

        public void Execute(Node[] nodes)
        {
            Debug.Log("Executing nodes!");

            foreach (Node node in nodes)
            {
                node.ResetExecution();
            }
            
            foreach (Node endNode in nodes.Where(node => node.EndNode).ToList())
            {
                endNode.Execute();
            }
        }
    }
}
