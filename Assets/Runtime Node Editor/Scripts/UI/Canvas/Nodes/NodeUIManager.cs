using RuntimeNodeEditor.UI.Canvas.Node.Components;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    internal class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private Texture2D _pointerTexture;

        private Camera _camera;
        private CanvasScaler _canvasScaler;
        
        [SerializeField]
        private NodeUISelection _nodeUISelection;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _canvasScaler = FindObjectOfType<CanvasScaler>();
            
            UISettings.nodeCanvasTransform = _parent.transform;
            UISettings.pointerTexture = _pointerTexture;
        }

        private void Update()
        {
            _nodeUISelection.ManageNodes(_camera);
            NodeUIDrag.ManageDrag(_camera, _canvasScaler);
        }

        public void Spawn(string id)
        {
            InitSpawnDrag(NodeUIFactory.CreateNode(id, Vector3.zero));
        }

        public void Spawn(string id, Vector3 position)
        {
            InitSpawnDrag(NodeUIFactory.CreateNode(id, position));
        }

        public NodeUI SpawnWithReturn(string id, Vector3 position)
        {
            NodeUI nodeUI = NodeUIFactory.CreateNode(id, position);
            InitSpawnDrag(nodeUI);

            return nodeUI;
        }

        private void InitSpawnDrag(NodeUI nodeUI)
        {
            NodeUIDrag.InitSpawnDrag(nodeUI);
        }
    }
}
