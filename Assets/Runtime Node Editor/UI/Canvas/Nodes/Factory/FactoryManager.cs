using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory
{
    public class FactoryManager : MonoBehaviour
    {
        public void Spawn(string id)
        {
            Spawn(id, Vector3.zero);
        }

        public void Spawn(string id, Vector3 position)
        {
            InitSpawnDrag(Factory.CreateNode(id, position));
        }

        public NodeUI SpawnWithReturn(string id, Vector3 position)
        {
            NodeUI nodeUI = Factory.CreateNode(id, position);
            InitSpawnDrag(nodeUI);

            return nodeUI;
        }

        private void InitSpawnDrag(NodeUI nodeUI)
        {
            Components.Drag.InitSpawnDrag(nodeUI);
        }
    }
}
