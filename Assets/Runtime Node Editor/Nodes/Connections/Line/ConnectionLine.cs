using UnityEngine;

namespace RuntimeNodeEditor.Node.Connection.Line
{
    internal partial class ConnectionLine
    {
        private readonly GameObject _lineObject;
        private readonly LineRenderer _lineRenderer;

        private Vector3 _startPosition;
        private Vector3 _endPosition;

        internal ConnectionLine(Transform parent, Material material, Vector3 start)
        {
            _lineObject = new GameObject
            {
                transform =
                {
                    name = "Line",
                    parent = parent
                }
            };

            _lineRenderer = _lineObject.AddComponent<LineRenderer>();

            UpdateWidth();

            _lineRenderer.material = new Material(material);

            _startPosition = start;
            _lineRenderer.SetPosition(0, start);
        }

        public void SetMaterial(Color color)
        {
            _lineRenderer.material.color = color;
        }
    }
}
