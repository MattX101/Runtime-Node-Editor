using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Line
{
    internal partial class ConnectionLine
    {
        private const float LineWidth = 0.1f;

        internal void UpdateWidth()
        {
            _lineRenderer.startWidth = LineWidth * CanvasData.ScalerFactor;
            _lineRenderer.endWidth = LineWidth * CanvasData.ScalerFactor;
        }

        internal void UpdateDraggingLine(Vector3 endPosition)
        {
            _endPosition = new Vector3(endPosition.x, endPosition.y, 100.0f);

            SetNumberOfPoints(_endPosition);
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, new Vector3(_endPosition.x, _endPosition.y, 100.0f));
            UpdatePointsPositions(_startPosition, _endPosition);
        }

        internal void UpdateLinePositions()
        {
            SetPositions();
            UpdatePoints();
        }
    }
}
