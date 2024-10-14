using Utils.Curves;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Line
{
    internal partial class ConnectionLine
    {
        private const int PositionCountMin = 8;
        private const int PositionCountMax = 32;

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
    }
}
