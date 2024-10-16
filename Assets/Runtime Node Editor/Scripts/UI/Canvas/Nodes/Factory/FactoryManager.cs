using RuntimeNodeEditor.UI.Canvas.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Factory
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
            UI.Canvas.Node.Components.Drag.InitSpawnDrag(nodeUI);
        }
    }
}
