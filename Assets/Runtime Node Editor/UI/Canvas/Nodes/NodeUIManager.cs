using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Node.Connection.Lines;
using RuntimeNodeEditor.UI.Canvas.Node.Components;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        [SerializeField]
        private ConnectionLines _connectionLines;

        [SerializeField]
        private Factory.FactoryManager _factoryManager;
        public Factory.FactoryManager FactoryManager
        {
            get => _factoryManager;
        }

        [Header("Nodes")]
        [SerializeField]
        private GameObject _nodesParent;

        void Update()
        {
            Selection.OnUpdate(this, _connectionLines);
            Drag.ManageDrag();
        }

        public void ResetOnValidate()
        {
            if (_nodesParent.transform.childCount > 0)
                return;

            Reset();
        }
        public void Reset()
        {
            Pan.Reset();
            Zoom.Reset();

            foreach (NodeUI node in GetComponentsInChildren<NodeUI>())
            {
                Selection.Delete(node, true);
            }
        }
    }
}
