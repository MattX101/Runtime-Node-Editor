using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Nodes.Lines;
using RuntimeNodeEditor.Nodes.Pointer;
using Utils.Curves;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Line
{
    public class NodeConnectionLine
    {
        private readonly GameObject _lineObject;
        private LineRenderer _lineRenderer;

        public InputPointer Input;
        private Vector3 _startPosition;

        public OutputPointer Output;
        private Vector3 _endPosition;

        private const float LineWidth = 0.1f;

        public NodeConnectionLine(Transform parent, Material material, Vector3 start)
        {
            _lineObject = new GameObject
            {
                transform =
                {
                    parent = parent,
                    name = "Line"
                }
            };

            _lineRenderer = _lineObject.AddComponent<LineRenderer>();

            UpdateWidth();

            _lineRenderer.material = new Material(material);

            _startPosition = start;
            _lineRenderer.SetPosition(0, start);
        }

        public void UpdateWidth()
        {
            _lineRenderer.startWidth = LineWidth * Zoom.Scale;
            _lineRenderer.endWidth = LineWidth * Zoom.Scale;
        }

        public void UpdateDraggingLine(Vector3 endPosition)
        {
            _endPosition = new Vector3(endPosition.x, endPosition.y, 100.0f);

            SetNumberOfPoints(_endPosition);

            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, new Vector3(_endPosition.x, _endPosition.y, 100.0f));

            UpdatePointsPositions(_startPosition, _endPosition);
        }

        public void UpdateLinePositions()
        {
            SetPositions();
            UpdatePoints();
        }

        public void UpdateLinePositionsOnLoad()
        {
            SetPositions();
            
            _startPosition *= Zoom.Scale;
            _endPosition *= Zoom.Scale;

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
            int numOfPointsByDistance = Mathf.CeilToInt(Vector3.Distance(_startPosition, endPosition));
            numOfPointsByDistance = Mathf.Clamp(numOfPointsByDistance, 8, 32);
            _lineRenderer.positionCount = numOfPointsByDistance;
        }

        private void UpdatePointsPositions(Vector3 a, Vector3 b)
        {
            if (_lineRenderer.positionCount <= 2)
                return;

            for (int i = 1; i < _lineRenderer.positionCount - 1; i++)
            {
                float x = Mathf.Lerp(a.x, b.x, (float)i / _lineRenderer.positionCount);
                float easeY = Mathf.Lerp(a.y, b.y, LinearEaseCurves.EaseInOutCos((float)i / _lineRenderer.positionCount));

                _lineRenderer.SetPosition(i, new Vector3(x, easeY, 100));
            }
        }

        public void DestroyLine()
        {
            LinesData.Remove(this);

            if (Input)  Input.Line = null;
            if (Output) Output.Lines.Remove(this);

            _lineRenderer = null;
            Object.Destroy(_lineObject);
        }
    }
}
