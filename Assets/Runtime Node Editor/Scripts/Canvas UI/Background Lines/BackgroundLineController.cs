using UnityEngine;

namespace RuntimeNodeEditor.Canvas.Lines
{
    public class BackgroundLineController
    {
        private GameObject _lineObject;

        protected LineRenderer lineRenderer;
        public LineRenderer LineRenderer
        {
            get { return lineRenderer; }
        }

        private Vector3 _start;
        private Vector3 _end;

        public Vector3 offset;

        public BackgroundLineController(string name, Transform parent, Vector3 start, Vector3 end, float lineWidth)
        {
            _lineObject = new GameObject();
            _lineObject.transform.parent = parent;
            _lineObject.name = name;

            DrawLine(start, end, lineWidth);
        }

        private void DrawLine(Vector3 start, Vector3 end, float lineWidth)
        {
            lineRenderer = _lineObject.AddComponent<LineRenderer>();

            _start = start;
            lineRenderer.SetPosition(0, _start);
            lineRenderer.startWidth = lineWidth;

            _end = end;
            lineRenderer.SetPosition(1, _end);
            lineRenderer.endWidth = lineWidth;
        }

        public void CreateLine(Material material, Color colour)
        {
            SetMaterial(material, colour);
        }

        public void UpdateHorizontalLine()
        {
            Vector3 axisOffset = new Vector3(0.0f, offset.y, 0.0f);

            lineRenderer.SetPosition(0, new Vector3(_start.x, (_start.y - axisOffset.y) * Zoom.scale, 999));
            lineRenderer.SetPosition(1, new Vector3(_end.x, (_end.y - axisOffset.y) * Zoom.scale, 999));
        }
        public void UpdateVerticalLine()
        {
            Vector3 axisOffset = new Vector3(offset.x, 0.0f, 0.0f);

            lineRenderer.SetPosition(0, new Vector3((_start.x - axisOffset.x) * Zoom.scale, _start.y, 999));
            lineRenderer.SetPosition(1, new Vector3((_end.x - axisOffset.x) * Zoom.scale, _end.y, 999));
        }

        public void SetMaterial(Material material, Color colour)
        {
            lineRenderer.material = material;
            AssignMaterial(colour);
        }
        protected void AssignMaterial(Color colour)
        {
            lineRenderer.material.color = colour;
        }
        public void UpdateMaterial(Color colour)
        {
            AssignMaterial(colour);
        }
    }
}
