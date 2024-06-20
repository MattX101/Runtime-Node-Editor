using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Components
{
    internal static class Drag
    {
        private static NodeUI _hover;
        private static NodeUI _selectedNodeUI;

        private static bool _dragOnSpawn = false;

        private static Vector3 _distanceFromCenter;

        public static void ManageDrag(Camera camera, CanvasScaler canvasScaler)
        {
            if (!CanvasData.canvasIsActive || UIData.tabOpened || UIData.windowOpened)
                return;

            if (_dragOnSpawn)
            {
                SpawnDrag(camera, canvasScaler);
            }
            else
            {
                OnClick(camera, canvasScaler);
                OnClickRelease();

                OnHover(camera);
                OnHoverLeave(camera);

                if (_selectedNodeUI && CanvasData.isDraging)
                    DragNode(camera, canvasScaler);
            }
        }

        public static void InitSpawnDrag(NodeUI nodeUI)
        {
            _selectedNodeUI = nodeUI;
            _dragOnSpawn = true;

            CanvasData.isDraging = true;
            CanvasData.canDrag = false;
        }
        private static void SpawnDrag(Camera camera, CanvasScaler canvasScaler)
        {
            DragNode(camera, canvasScaler);

            if (UnityEngine.Input.GetMouseButtonDown(0))
                ValidateDrop();
        }

        private static void OnClick(Camera camera, CanvasScaler canvasScaler)
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0))
                return;

            _selectedNodeUI = SelectNodeUI(Physics2D.Raycast(
                    MouseController.GetMouseWorldPosition(camera),
                    Vector2.zero)
                    );

            if (!_selectedNodeUI)
                return;

            _selectedNodeUI.BlockRaycasts(false);

            CanvasData.isDraging = true;
            CanvasData.canDrag = false;

            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(camera, canvasScaler.referenceResolution);
            Vector3 nodeLocalPos = _selectedNodeUI.rootRect.localPosition;
            _distanceFromCenter = mousePos - nodeLocalPos - (Pan.positionFromOrigin / Zoom.scale);
        }

        private static void OnClickRelease()
        {
            if (!UnityEngine.Input.GetMouseButtonUp(0))
                return;

            ValidateDrop();
        }

        private static void OnHover(Camera camera)
        {
            NodeUI newNodeUI = SelectNodeUI(Physics2D.Raycast(
                MouseController.GetMouseWorldPosition(camera),
                Vector2.zero)
                );

            if (!newNodeUI)
                return;

            if (_hover)
                _hover.SetAlpha(1.0f);

            _hover = newNodeUI;
            _hover.SetAlpha(0.5f);
        }

        private static void OnHoverLeave(Camera camera)
        {
            if (!_hover)
                return;

            if (SelectNodeUI(Physics2D.Raycast(MouseController.GetMouseWorldPosition(camera), Vector2.zero)) != null)
                return;

            _hover.SetAlpha(1.0f);
            _hover = null;
        }

        private static NodeUI SelectNodeUI(RaycastHit2D hit)
        {
            if (!hit.collider)
                return null;

            if (!hit.collider.gameObject.TryGetComponent(out RuntimeNodeEditor.Nodes.Node.Node node))
                return null;
            
            return node.gameObject.GetComponent<NodeUI>();
        }

        private static void Reset()
        {
            _selectedNodeUI = null;
            _dragOnSpawn = false;
        }

        private static void DragNode(Camera camera, CanvasScaler canvasScaler)
        {
            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(camera, canvasScaler.referenceResolution);
            Vector3 nodePos = mousePos - (Pan.positionFromOrigin / Zoom.scale);

            _selectedNodeUI.rootRect.localPosition = new Vector3(
                nodePos.x - _distanceFromCenter.x,
                nodePos.y - _distanceFromCenter.y,
                _selectedNodeUI.rootRect.localPosition.z);
        }

        private static void ValidateDrop()
        {
            if (_selectedNodeUI)
                Drop();

            Reset();
        }
        private static void Drop()
        {
            _selectedNodeUI.BlockRaycasts(true);

            _dragOnSpawn = false;
            CanvasData.isDraging = false;
            CanvasData.canDrag = true;

            _distanceFromCenter = Vector3.zero;

            _selectedNodeUI = null;
        }
    }
}