using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.CanvasInput;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static class NodeUIDrag
    {
        private static NodeUI hover;
        public static NodeUI selectedNodeUI;

        public static bool dragOnNodeSpawn = false;

        private static Vector3 _distanceFromCenter;

        public static void ManageDrag(Camera camera, CanvasScaler canvasScaler)
        {
            if (!CanvasData.canvasIsActive || UIData.tabOpened || UIData.windowOpened)
                return;

            if (dragOnNodeSpawn)
            {
                SpawnDrag(camera, canvasScaler);
            }
            else
            {
                OnClick(camera, canvasScaler);
                OnClickRelease();

                OnHover(camera);
                OnHoverLeave(camera);

                if (selectedNodeUI && CanvasData.isDraging)
                    Drag(camera, canvasScaler);
            }
        }

        public static void InitSpawnDrag(NodeUI nodeUI)
        {
            selectedNodeUI = nodeUI;
            dragOnNodeSpawn = true;

            CanvasData.isDraging = true;
            CanvasData.canDrag = false;
        }
        private static void SpawnDrag(Camera camera, CanvasScaler canvasScaler)
        {
            Drag(camera, canvasScaler);

            if (Input.GetMouseButtonDown(0))
                ValidateDrop();
        }

        private static void OnClick(Camera camera, CanvasScaler canvasScaler)
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            selectedNodeUI = SelectNodeUI(Physics2D.Raycast(
                    MouseController.GetMouseWorldPosition(camera),
                    Vector2.zero)
                    );

            if (!selectedNodeUI)
                return;

            selectedNodeUI.BlockRaycasts(false);

            CanvasData.isDraging = true;
            CanvasData.canDrag = false;

            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(camera, canvasScaler.referenceResolution);
            Vector3 nodeLocalPos = selectedNodeUI.rootRect.localPosition;
            _distanceFromCenter = mousePos - nodeLocalPos - (Pan.positionFromOrigin / Zoom.scale);
        }

        private static void OnClickRelease()
        {
            if (!Input.GetMouseButtonUp(0))
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

            if (hover)
                hover.SetAlpha(1.0f);

            hover = newNodeUI;
            hover.SetAlpha(0.5f);
        }

        private static void OnHoverLeave(Camera camera)
        {
            if (!hover)
                return;

            if (SelectNodeUI(Physics2D.Raycast(MouseController.GetMouseWorldPosition(camera), Vector2.zero)) != null)
                return;

            hover.SetAlpha(1.0f);
            hover = null;
        }

        private static NodeUI SelectNodeUI(RaycastHit2D hit)
        {
            if (!hit.collider)
                return null;

            if (!hit.collider.gameObject.TryGetComponent(out RuntimeNodeEditor.Node.Node node))
                return null;
            
            return node.gameObject.GetComponent<NodeUI>();
        }

        private static void Reset()
        {
            selectedNodeUI = null;
        }

        private static void Drag(Camera camera, CanvasScaler canvasScaler)
        {
            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(camera, canvasScaler.referenceResolution);
            Vector3 nodePos = mousePos - (Pan.positionFromOrigin / Zoom.scale);

            selectedNodeUI.rootRect.localPosition = new Vector3(
                nodePos.x - _distanceFromCenter.x,
                nodePos.y - _distanceFromCenter.y,
                selectedNodeUI.rootRect.localPosition.z);
        }

        private static void ValidateDrop()
        {
            if (selectedNodeUI)
                Drop();

            Reset();
        }
        private static void Drop()
        {
            selectedNodeUI.BlockRaycasts(true);

            dragOnNodeSpawn = false;
            CanvasData.isDraging = false;
            CanvasData.canDrag = true;

            _distanceFromCenter = Vector3.zero;

            selectedNodeUI = null;
        }
    }
}