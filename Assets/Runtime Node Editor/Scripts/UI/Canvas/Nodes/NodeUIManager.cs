using RuntimeNodeEditor.Nodes.Lines;
using RuntimeNodeEditor.UI.Canvas.Node.Components;
using RuntimeNodeEditor.UI.Canvas.Nodes.Components;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Nodes
{
    internal class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private Texture2D _pointerTexture;

        private Camera _camera;
        private CanvasScaler _canvasScaler;

        [SerializeField]
        private NodeUIManager _nodeUIManager;

        [SerializeField]
        private ConnectionLines _linesController;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _canvasScaler = FindObjectOfType<CanvasScaler>();
            
            UISettings.nodeCanvasTransform = _parent.transform;
            UISettings.pointerTexture = _pointerTexture;
        }

        private void Update()
        {
            Selection.OnUpdate(_camera, _nodeUIManager, _linesController);
            Drag.ManageDrag(_camera, _canvasScaler);
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
