using RuntimeNodeEditor.UI.Canvas;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Utils.Curves;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Line
{
    public class LineController
    {
        private GameObject lineObject;
        private LineRenderer lineRenderer;

        public InputPointer input;
        private Vector3 startPosition;

        public OutputPointer output;
        private Vector3 endPosition;

        private float _lineWidth = 0.1f;

        public LineController(Transform parent, Material material, Vector3 start)
        {
            lineObject = new GameObject();
            lineObject.transform.parent = parent;
            lineObject.transform.name = "Line";

            lineRenderer = lineObject.AddComponent<LineRenderer>();

            UpdateWidth();

            lineRenderer.material = new Material(material);

            startPosition = start;
            lineRenderer.SetPosition(0, start);
        }

        public void UpdateWidth()
        {
            lineRenderer.startWidth = _lineWidth * Zoom.scale;
            lineRenderer.endWidth = _lineWidth * Zoom.scale;
        }

        public void UpdateDraggingLine(Vector3 endPosition)
        {
            this.endPosition = new Vector3(endPosition.x, endPosition.y, 100.0f);

            SetNumberOfPoints(this.endPosition);

            lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(this.endPosition.x, this.endPosition.y, 100.0f));

            UpdatePointsPositions(startPosition, this.endPosition);
        }

        public void UpdateLinePositions()
        {
            startPosition = output.transform.position;
            endPosition = input.transform.position;

            SetNumberOfPoints(endPosition);

            lineRenderer.SetPosition(0, endPosition);
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, startPosition);

            UpdatePointsPositions(endPosition, startPosition);
        }

        private void SetNumberOfPoints(Vector3 endPosition)
        {
            int numOfPointsByDistance = Mathf.CeilToInt(Vector3.Distance(startPosition, endPosition));
            numOfPointsByDistance = Mathf.Clamp(numOfPointsByDistance, 8, 32);
            lineRenderer.positionCount = numOfPointsByDistance;
        }

        private void UpdatePointsPositions(Vector3 a, Vector3 b)
        {
            if (lineRenderer.positionCount <= 2)
                return;

            for (int i = 1; i < lineRenderer.positionCount - 1; i++)
            {
                float x = Mathf.Lerp(a.x, b.x, (float)i / lineRenderer.positionCount);
                float easeY = Mathf.Lerp(a.y, b.y, LinearEaseCurves.EaseInOutCos((float)i / lineRenderer.positionCount));

                lineRenderer.SetPosition(i, new Vector3(x, easeY, 100));
            }
        }

        public void DestroyLine()
        {
            if (input != null) input.line = null;
            if (output != null) output.lines.Remove(this);

            lineRenderer = null;
            Object.Destroy(lineObject);
        }
    }
}
