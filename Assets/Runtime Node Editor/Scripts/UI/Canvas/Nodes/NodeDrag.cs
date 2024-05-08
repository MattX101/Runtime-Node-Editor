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

            if (spawnDrag)
                DragNode();
        }

        private void OnMouseOver()
        {
            if (!CanvasData.canvasIsActive || !CanvasData.canDrag || !CanvasData.canPoint || _dragThisNode)
                return;

            nodeUI.highLightAlpha = true;
        }

        private void OnMouseDown()
        {
            nodeUI.canvasGroup.blocksRaycasts = false;

            _dragThisNode = true;
            CanvasData.isDraging = true;
            CanvasData.canDrag = false;
            
            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(_camera, _canvasScaler.referenceResolution);
            Vector3 nodeLocalPos = target.localPosition;
            _distanceFromCenter = mousePos - nodeLocalPos - (Pan.positionFromOrigin / Zoom.scale);
        }

        private void OnMouseExit()
        {
            nodeUI.highLightAlpha = false;
            nodeUI.canvasGroup.blocksRaycasts = true;
        }

        private void OnMouseDrag()
        {
            if (_InValid)
                return;
            
            DragNode();
        }

        private void OnMouseUp()
        {
            if (_InValid)
                return;
            
            DropNode();
        }
        
        private bool _Valid
        {
            get => _dragThisNode;
        }
        private bool _InValid
        {
            get => _Valid.Equals(false);
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
