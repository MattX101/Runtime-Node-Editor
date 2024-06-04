using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.CanvasInput;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public class NodeUIDrag
    {
        private NodeUI hover;
        public NodeUI selectedNodeUI;

        public bool spawnDrag = false;

        private Vector3 _distanceFromCenter;

        public void ManageDrag(Camera camera, CanvasScaler canvasScaler)
        {
            if (!CanvasData.canvasIsActive || UIData.tabOpened || UIData.windowOpened)
                return;

            if (spawnDrag)
            {
                SpawnDrag(camera, canvasScaler);
            }
            else
            {
                OnClick(camera, canvasScaler);
                OnClickRelease();

                OnHover(camera);
                OnHoverLeave(camera);

                if (selectedNodeUI != null && CanvasData.isDraging)
                    Drag(camera, canvasScaler);
            }
        }

        public void InitSpawnDrag(NodeUI nodeUI, bool drag)
        {
            if (!drag)
                return;

            selectedNodeUI = nodeUI;
            spawnDrag = drag;

            CanvasData.isDraging = true;
            CanvasData.canDrag = false;
        }
        private void SpawnDrag(Camera camera, CanvasScaler canvasScaler)
        {
            Drag(camera, canvasScaler);

            if (Input.GetMouseButtonDown(0))
                ValidateDrop();
        }

        private void OnClick(Camera camera, CanvasScaler canvasScaler)
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            selectedNodeUI = SelectNodeUI(Physics2D.Raycast(
                    MouseController.GetMouseWorldPosition(camera),
                    Vector2.zero)
                    );

            if (selectedNodeUI == null)
                return;

            selectedNodeUI.BlockRaycasts(false);

            CanvasData.isDraging = true;
            CanvasData.canDrag = false;

            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(camera, canvasScaler.referenceResolution);
            Vector3 nodeLocalPos = selectedNodeUI.rootRect.localPosition;
            _distanceFromCenter = mousePos - nodeLocalPos - (Pan.positionFromOrigin / Zoom.scale);
        }

        private void OnClickRelease()
        {
            if (!Input.GetMouseButtonUp(0))
                return;

            ValidateDrop();
        }

        private void OnHover(Camera camera)
        {
            NodeUI newNodeUI = SelectNodeUI(Physics2D.Raycast(
                MouseController.GetMouseWorldPosition(camera),
                Vector2.zero)
                );

            if (newNodeUI == null)
                return;

            if (hover != null)
                hover.SetAlpha(1.0f);

            hover = newNodeUI;
            hover.SetAlpha(0.5f);
        }

        private void OnHoverLeave(Camera camera)
        {
            if (hover == null)
                return;

            if (SelectNodeUI(Physics2D.Raycast(MouseController.GetMouseWorldPosition(camera), Vector2.zero)) != null)
                return;

            hover.SetAlpha(1.0f);
            hover = null;
        }

        private NodeUI SelectNodeUI(RaycastHit2D hit)
        {
            if (hit.collider == null)
                return null;

            if (!hit.collider.gameObject.TryGetComponent(out RuntimeNodeEditor.Node.Node node))
                return null;
            
            return node.gameObject.GetComponent<NodeUI>();
        }

        private void Reset()
        {
            selectedNodeUI = null;
        }

        private void Drag(Camera camera, CanvasScaler canvasScaler)
        {
            Vector3 mousePos = MouseController.GetMousePositionRelativeToCenter(camera, canvasScaler.referenceResolution);
            Vector3 nodePos = mousePos - (Pan.positionFromOrigin / Zoom.scale);

            selectedNodeUI.rootRect.localPosition = new Vector3(
                nodePos.x - _distanceFromCenter.x,
                nodePos.y - _distanceFromCenter.y,
                selectedNodeUI.rootRect.localPosition.z);
        }

        private void ValidateDrop()
        {
            if (selectedNodeUI != null)
                Drop();

            Reset();
        }
        private void Drop()
        {
            selectedNodeUI.BlockRaycasts(true);

            spawnDrag = false;
            CanvasData.isDraging = false;
            CanvasData.canDrag = true;

            _distanceFromCenter = Vector3.zero;

            selectedNodeUI = null;
        }
    }
}