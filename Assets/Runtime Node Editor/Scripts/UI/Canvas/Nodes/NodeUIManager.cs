using RuntimeNodeEditor.UI.Canvas.Node.Components;
using RuntimeNodeEditor.UI.Canvas.Nodes.Components;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RuntimeNodeEditor.Nodes.Lines;
using RuntimeNodeEditor.Input;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes
{
    internal class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        [SerializeField] private ConnectionLines connectionLines;

        [SerializeField] private GameObject nodesObject;

        private void Update()
        {
            Selection.OnUpdate(this, connectionLines);
            Drag.ManageDrag();
        }

        public void Reset()
        {
            Pan.Reset();
            Zoom.Reset();

            foreach (RuntimeNodeEditor.Nodes.Node.Node node in GetComponentsInChildren<RuntimeNodeEditor.Nodes.Node.Node>())
                Selection.Delete(node, true);
        }

        public void Spawn(string id)
        {
            InitSpawnDrag(Factory.CreateNode(id, Vector3.zero));
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
            Drag.InitSpawnDrag(nodeUI);
        }
    }
}
