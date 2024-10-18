using RuntimeNodeEditor.UI.Canvas.Node.Components;
using RuntimeNodeEditor.Node.Connection.Lines;
using RuntimeNodeEditor.Input;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    internal class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        [SerializeField] private ConnectionLines connectionLines;

        [SerializeField] private Factory.FactoryManager factoryManager;
        internal Factory.FactoryManager FactoryManager => factoryManager;

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

            foreach (RuntimeNodeEditor.Node.Node node in GetComponentsInChildren<RuntimeNodeEditor.Node.Node>())
                Selection.Delete(node, true);
        }
    }
}
