using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Nodes.Lines;
using RuntimeNodeEditor.Nodes.Pointer;
using Utils.Curves;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Line
{
    internal class NodeConnectionLine
    {
        private readonly GameObject _lineObject;
        private readonly LineRenderer _lineRenderer;

        internal InputPointer Input;
        private Vector3 _startPosition;

        internal OutputPointer Output;
        private Vector3 _endPosition;

        private const float LineWidth = 0.1f;

        private const int PositionCountMin = 8;
        private const int PositionCountMax = 32;

        internal NodeConnectionLine(Material material, Vector3 start)
        {
            _lineObject = new GameObject
            {
                transform =
                {
                    name = "Line"
                }
            };

            _lineRenderer = _lineObject.AddComponent<LineRenderer>();

            UpdateWidth();

            _lineRenderer.material = new Material(material);

            _startPosition = start;
            _lineRenderer.SetPosition(0, start);
        }

        internal void UpdateWidth()
        {
            _lineRenderer.startWidth = LineWidth * CanvasData.CanvasScaler.scaleFactor;
            _lineRenderer.endWidth = LineWidth * CanvasData.CanvasScaler.scaleFactor;
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

        internal void UpdateLinePositionsOnLoad()
        {
            SetPositions();
            
            _startPosition *= CanvasData.CanvasScaler.scaleFactor;
            _endPosition *= CanvasData.CanvasScaler.scaleFactor;

            UpdatePoints();
        }

        private void SetPositions()
        {
            _startPosition = Output.transform.position;
            _endPosition = Input.transform.position;
        }

        private void UpdatePoints()
        {
            SetNumberOfPoints(_endPosition);

            _lineRenderer.SetPosition(0, _endPosition);
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _startPosition);

            UpdatePointsPositions(_endPosition, _startPosition);
        }

        private void SetNumberOfPoints(Vector3 endPosition)
        {
            _lineRenderer.positionCount = 
                Mathf.Clamp(
                    Mathf.CeilToInt(Vector3.Distance(_startPosition, endPosition)),
                    PositionCountMin,
                    PositionCountMax);
        }

        private void UpdatePointsPositions(Vector3 a, Vector3 b)
        {
            if (_lineRenderer.positionCount <= 2)
                return;

            for (int i = 1; i < _lineRenderer.positionCount - 1; i++)
            {
                _lineRenderer.SetPosition(
                    i, 
                    new Vector3(
                        Mathf.Lerp(a.x, b.x, (float)i / _lineRenderer.positionCount),
                        Mathf.Lerp(a.y, b.y, LinearEaseCurves.EaseInOutCos((float)i / _lineRenderer.positionCount)), 
                        100)
                    );
            }
        }

        internal void DestroyLine()
        {
            LinesData.Remove(this);

            if (Input)
                Input.SetLineToNull();
            if (Output)
                Output.RemoveLine(this);

            Object.Destroy(_lineObject);
        }
    }
}
