using RuntimeNodeEditor.UI.Canvas;
using RuntimeNodeEditor.UI.Canvas.Data;
using RuntimeNodeEditor.UI.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeDrag : MonoBehaviour
    {
        private Camera _camera;
        public RectTransform target;
        private CanvasScaler _canvasScaler;

        public NodeUI nodeUI;

        private bool _dragThisNode = false;
        [NonSerialized] public bool spawnDrag = false;

        private Vector3 _distanceFromCenter;

        public void Awake()
        {
            _camera = FindObjectOfType<Camera>();

            _canvasScaler = FindObjectOfType<CanvasScaler>();
        }

        private void Update()
        {
            if (!CanvasData.canvasIsActive || UIData.tabOpened || UIData.windowOpened)
                return;

            SpawnDrag();
            NormalDrag();
        }

        private void OnMouseOver()
        {
            if (!CanvasData.canvasIsActive || !CanvasData.canDrag || _dragThisNode || !CanvasData.canPoint)
                return;

            nodeUI.highLightAlpha = true;
            if (Input.GetMouseButton(0))
            {
                nodeUI.canvasGroup.blocksRaycasts = false;

                _dragThisNode = true;
                CanvasData.isDraging = true;
                CanvasData.canDrag = false;

                Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(_camera, _canvasScaler.referenceResolution);
                Vector3 nodeLocalPos = target.localPosition;
                _distanceFromCenter = mousePos - nodeLocalPos - (Pan.positionFromOrigin / Zoom.scale);
            }
        }

        private void OnMouseExit()
        {
            nodeUI.highLightAlpha = false;
            nodeUI.canvasGroup.blocksRaycasts = true;
        }

        private void SpawnDrag()
        {
            if (!spawnDrag)
                return;

            if (Input.GetMouseButtonDown(0))
                DropNode();

            DragNode();
        }

        private void NormalDrag()
        {
            if (!_dragThisNode || spawnDrag)
                return;

            if (!Input.GetMouseButton(0))
                DropNode();

            DragNode();
        }

        private void DragNode()
        {
            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(_camera, _canvasScaler.referenceResolution);
            Vector3 nodePos = mousePos - (Pan.positionFromOrigin / Zoom.scale);

            target.localPosition = new Vector3(
                nodePos.x - _distanceFromCenter.x, 
                nodePos.y - _distanceFromCenter.y, 
                target.localPosition.z);
        }

        private void DropNode()
        {
            nodeUI.canvasGroup.blocksRaycasts = false;

            _dragThisNode = false;
            spawnDrag = false;
            CanvasData.isDraging = false;
            CanvasData.canDrag = true;

            _distanceFromCenter = Vector3.zero;
        }
    }
}
