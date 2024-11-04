using RuntimeNodeEditor.UI.Canvas.Node.Components;
using RuntimeNodeEditor.Node.Connection.Lines;
using RuntimeNodeEditor.Input;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        [SerializeField] 
        private ConnectionLines _connectionLines;

        [SerializeField] 
        private Factory.FactoryManager _factoryManager;
        internal Factory.FactoryManager FactoryManager
        {
            get => _factoryManager;
        }

        private void Update()
        {
            Selection.OnUpdate(this, _connectionLines);
            Drag.ManageDrag();
        }

        public void Reset()
        {
            Pan.Reset();
            Zoom.Reset();

            foreach (RuntimeNodeEditor.Node.Node node in GetComponentsInChildren<RuntimeNodeEditor.Node.Node>())
            {
                Selection.Delete(node, true);
            }
        }
    }
}
