using RuntimeNodeEditor.Canvas;
using RuntimeNodeEditor.Canvas.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.RuntimeNode.UI
{
    public class NodeDrag : MonoBehaviour
    {
        private Camera _camera;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private CanvasScaler _canvasScaler;

        private bool _dragThisNode = false;
        [NonSerialized] public bool spawnDrag = false;

        private Vector3 _distanceFromCenter;

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();

            _rectTransform = GetComponentInParent<RectTransform>();
            _canvasGroup = GetComponentInParent<CanvasGroup>();
            _canvasScaler = FindObjectOfType<CanvasScaler>();
        }

        private void Update()
        {
            if (spawnDrag)
                if (Input.GetMouseButtonDown(0)) DropNode();
                else DragNode();
            else if (_dragThisNode && !spawnDrag)
                if (!Input.GetMouseButton(0)) DropNode();
                else DragNode();
        }

        private void OnMouseOver()
        {
            if (CanvasData.canDrag && !_dragThisNode && CanvasData.canPoint)
            {
                _canvasGroup.alpha = 0.5f;
                if (Input.GetMouseButton(0))
                {
                    _canvasGroup.blocksRaycasts = true;

                    _dragThisNode = true;
                    CanvasData.isDraging = true;
                    CanvasData.canDrag = false;
                    
                    Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(_camera, _canvasScaler.referenceResolution);
                    Vector3 nodeLocalPos = _rectTransform.localPosition;
                    _distanceFromCenter = mousePos - nodeLocalPos - (Pan.positionFromOrigin / Zoom.scale);
                }
            }
        }

        private void OnMouseExit()
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.blocksRaycasts = false;
        }

        private void DragNode()
        {
            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(_camera, _canvasScaler.referenceResolution);
            Vector3 nodePos = mousePos - (Pan.positionFromOrigin / Zoom.scale);

            _rectTransform.localPosition = new Vector3(nodePos.x - _distanceFromCenter.x, nodePos.y - _distanceFromCenter.y, _rectTransform.localPosition.z);
        }

        private void DropNode()
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.blocksRaycasts = false;

            _dragThisNode = false;
            spawnDrag = false;
            CanvasData.isDraging = false;
            CanvasData.canDrag = true;

            _distanceFromCenter = Vector3.zero;
        }
    }
}
