using RuntimeNodeEditor.UI.Canvas.Nodes.Components;
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
    }
}
