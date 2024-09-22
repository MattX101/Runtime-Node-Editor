using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Nodes.Line;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Lines
{
    public partial class ConnectionLines : MonoBehaviour
    {
        private Vector2 _mousePos;
        private RaycastHit2D _raycastHit2D;

        private ConnectionLine _currentConnectionLine;

        private void Update()
        {
            if (UIData.TabOrWindowOpened)
                return;

            _raycastHit2D = Physics2D.Raycast(_mousePos, Vector2.zero);

            _mousePos = MouseController.MouseWorldPosition;

            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                CreateOnClick();
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0) && CanvasData.IsPointing)
            {
                DropLine();
            }
            else
            {
                _currentConnectionLine?.UpdateDraggingLine(_mousePos);
            }

            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                LinesData.DeletePointerConnectionsOnClick(_raycastHit2D);
            }

            if (LinesData.NotNullOrEmpty)
                return;

            foreach (ConnectionLine line in LinesData.DroppedLinesArray)
            {
                UpdateLineWidth(line);
            }
        }

        private void UpdateLineWidth(ConnectionLine line)
        {
            line.UpdateWidth();
        }
    }
}
