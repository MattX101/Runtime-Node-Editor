using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory
{
    public class FactoryManager : MonoBehaviour
    {
        [SerializeField]
        private Transform _nodesParent;

        [SerializeField]
        private bool _singleExecutionNode = false;
        
        private bool _executionNodeSpawned = false;

        public void Spawn(GameObject node)
        {
            InitSpawnDrag(
                Instantiate(node, _nodesParent).GetComponent<NodeUI>()
                );
        }

        public void SpawnExecutionNode(GameObject node)
        {
            if (_executionNodeSpawned == true && _singleExecutionNode == true)
            {
                Debug.LogError("Only one end node can be active!");

                return;
            }
            else
            {
                Spawn(node);

                _executionNodeSpawned = true;
            }
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

        public void ExecutionNodeDeleted()
        {
            _executionNodeSpawned = false;
        }
    }
}
