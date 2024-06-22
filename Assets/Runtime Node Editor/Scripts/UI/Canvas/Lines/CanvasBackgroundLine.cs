using RuntimeNodeEditor.Input;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Line
{
    internal class CanvasBackgroundLine
    {
        private readonly GameObject _lineObject;

        public LineRenderer LineRenderer { get; private set; }

        private readonly float _lineWidth;
        private readonly Vector3 _start, _end;

        public Vector3 Offset;
        
        public CanvasBackgroundLine(string name, Transform parent, Vector3 start, Vector3 end, float lineWidth)
        {
            _lineObject = new GameObject
            {
                transform =
                {
                    parent = parent
                },
                name = name
            };

            _lineWidth = lineWidth;
            
            _start = start;
            _end = end;

            DrawLine();
        }

        private void DrawLine()
        {
            LineRenderer = _lineObject.AddComponent<LineRenderer>();

            LineRenderer.SetPosition(0, _start);
            LineRenderer.startWidth = _lineWidth;

            LineRenderer.SetPosition(1, _end);
            LineRenderer.endWidth = _lineWidth;
        }

        public void UpdateHorizontalLine()
        {
            Vector3 axisOffset = new Vector3(0.0f, Offset.y, 0.0f);

            LineRenderer.SetPosition(0, new Vector3(_start.x, (_start.y - axisOffset.y) * Zoom.Scale, 999));
            LineRenderer.SetPosition(1, new Vector3(_end.x, (_end.y - axisOffset.y) * Zoom.Scale, 999));

            UpdateLineWidth();
        }
        public void UpdateVerticalLine()
        {
            Vector3 axisOffset = new Vector3(Offset.x, 0.0f, 0.0f);

            LineRenderer.SetPosition(0, new Vector3((_start.x - axisOffset.x) * Zoom.Scale, _start.y, 999));
            LineRenderer.SetPosition(1, new Vector3((_end.x - axisOffset.x) * Zoom.Scale, _end.y, 999));

            UpdateLineWidth();
        }

        private void UpdateLineWidth()
        {
            LineRenderer.startWidth = _lineWidth * Zoom.Scale;
            LineRenderer.endWidth = _lineWidth * Zoom.Scale;
        }

        public void SetMaterial(Material material, Color colour)
        {
            LineRenderer.material = material;
            AssignMaterial(colour);
        }
        private void AssignMaterial(Color colour)
        {
            LineRenderer.material.color = colour;
        }
        public void UpdateMaterial(Color colour)
        {
            AssignMaterial(colour);
        }
    }
}
