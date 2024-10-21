using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node.Connection.Line;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Connection.Lines
{
    public partial class ConnectionLines
    {
        private OutputPointer _currentOutputPointer;

        [SerializeField]
        private Transform _linesParent;

        [SerializeField] 
        private Material sourceMaterial;

        private void Destroy(ConnectionLine line)
        {
            line.DestroyLine();
        }

        private void CreateOnClick()
        {
            if (!CanvasData.CanPoint)
                return;

            if (!_raycastHit2D.collider || _raycastHit2D.collider.TryGetComponent(out OutputPointer output) == false)
                return;

            CanvasData.IsPointing = true;
            CanvasData.CanPoint = false;

            Create(output);
        }

        private void Create(OutputPointer output)
        {
            _currentConnectionLine = new ConnectionLine(_linesParent, sourceMaterial, new Vector3(_mousePos.x, _mousePos.y, 100.0f))
            {
                Output = output
            };

            _currentOutputPointer = output;

            output.AddLine(_currentConnectionLine);
        }

        private void DropLine()
        {
            if (!LineDropped())
            {
                Destroy(_currentConnectionLine);
            }

            CanvasData.IsPointing = false;
            CanvasData.CanPoint = true;

            _currentConnectionLine = null;
            _currentOutputPointer = null;
        }
    }
}
