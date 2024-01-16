using UnityEngine;

namespace RuntimeNodeEditor.Canvas.Lines
{
    public class BackgroundLineController
    {
        private GameObject _lineObject;

        private LineRenderer _lineRenderer;
        public LineRenderer LineRenderer
        {
            get { return _lineRenderer; }
        }

        private Vector3 _start;
        private Vector3 _end;

        public Vector3 offset;

        private float _lineWidth;

        public BackgroundLineController(string name, Transform parent, Vector3 start, Vector3 end, float lineWidth)
        {
            _lineObject = new GameObject();
            _lineObject.transform.parent = parent;
            _lineObject.name = name;

            _lineWidth = lineWidth;

            DrawLine(start, end);
        }

        private void DrawLine(Vector3 start, Vector3 end)
        {
            _lineRenderer = _lineObject.AddComponent<LineRenderer>();

            _start = start;
            _lineRenderer.SetPosition(0, _start);
            _lineRenderer.startWidth = _lineWidth;

            _end = end;
            _lineRenderer.SetPosition(1, _end);
            _lineRenderer.endWidth = _lineWidth;
        }

        public void CreateLine(Material material, Color colour)
        {
            SetMaterial(material, colour);
        }

        public void UpdateHorizontalLine()
        {
            Vector3 axisOffset = new Vector3(0.0f, offset.y, 0.0f);

            _lineRenderer.SetPosition(0, new Vector3(_start.x, (_start.y - axisOffset.y) * Zoom.scale, 999));
            _lineRenderer.SetPosition(1, new Vector3(_end.x, (_end.y - axisOffset.y) * Zoom.scale, 999));

            UpdateLineWidth();
        }
        public void UpdateVerticalLine()
        {
            Vector3 axisOffset = new Vector3(offset.x, 0.0f, 0.0f);

            _lineRenderer.SetPosition(0, new Vector3((_start.x - axisOffset.x) * Zoom.scale, _start.y, 999));
            _lineRenderer.SetPosition(1, new Vector3((_end.x - axisOffset.x) * Zoom.scale, _end.y, 999));

            UpdateLineWidth();
        }

        private void UpdateLineWidth()
        {
            _lineRenderer.startWidth = _lineWidth * Zoom.scale;
            _lineRenderer.endWidth = _lineWidth * Zoom.scale;
        }

        public void SetMaterial(Material material, Color colour)
        {
            _lineRenderer.material = material;
            AssignMaterial(colour);
        }
        private void AssignMaterial(Color colour)
        {
            _lineRenderer.material.color = colour;
        }
        public void UpdateMaterial(Color colour)
        {
            AssignMaterial(colour);
        }
    }
}
