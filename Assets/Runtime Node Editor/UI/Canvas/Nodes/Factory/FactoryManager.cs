using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory
{
    public class FactoryManager : MonoBehaviour
    {
        [SerializeField]
        private Transform _nodesParent;

        public void Spawn(GameObject node)
        {
            InitSpawnDrag(
                Instantiate(node, _nodesParent).GetComponent<NodeUI>()
                );
        }

        public GameObject ReturnSpawn(GameObject node)
        {
            GameObject nodeObject = Instantiate(node, _nodesParent);
            
            InitSpawnDrag(nodeObject.GetComponent<NodeUI>());

            return nodeObject;
        }

        public NodeUI ReturnSpawnUI(NodeUI node)
        {
            GameObject nodeObject = Instantiate(node.gameObject, _nodesParent);

            NodeUI nodeUI = nodeObject.GetComponent<NodeUI>();
            InitSpawnDrag(nodeUI);

            return nodeUI;
        }

        private void InitSpawnDrag(NodeUI nodeUI)
        {
            Components.Drag.InitSpawnDrag(nodeUI);
        }
    }
}
