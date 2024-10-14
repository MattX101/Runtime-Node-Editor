using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Factory
{
    public class FactoryManager : MonoBehaviour
    {
        public void Spawn(string id)
        {
            Factory.CreateNode(id, Vector3.zero);
            //InitSpawnDrag(Factory.CreateNode(id, Vector3.zero));
        }

        public void Spawn(string id, Vector3 position)
        {
            Factory.CreateNode(id, position);
            //InitSpawnDrag(Factory.CreateNode(id, position));
        }

        public NodeUI SpawnWithReturn(string id, Vector3 position)
        {
            NodeUI nodeUI = Factory.CreateNode(id, position);
            //InitSpawnDrag(nodeUI);

            return nodeUI;
        }

        /*private void InitSpawnDrag(NodeUI nodeUI)
        {
            Drag.InitSpawnDrag(nodeUI);
        }*/
    }
}
