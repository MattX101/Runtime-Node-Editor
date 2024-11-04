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
        private Material _sourceMaterial;

        private void Destroy(ConnectionLine line)
        {
            line.DestroyLine();
        }

        private void CreateOnClick()
        {
            if (!GlobalData.CanPoint)
                return;

            if (!_raycastHit2D.collider || _raycastHit2D.collider.TryGetComponent(out OutputPointer Output) == false)
                return;

            GlobalData.IsPointing = true;
            GlobalData.CanPoint = false;

            Create(Output);
        }

        private void Create(OutputPointer Output)
        {
            _currentConnectionLine = new ConnectionLine(_linesParent, _sourceMaterial, new Vector3(_mousePos.x, _mousePos.y, 100.0f))
            {
                Output = Output
            };

            _currentOutputPointer = Output;

            Output.AddLine(_currentConnectionLine);
        }

        private void DropLine()
        {
            if (!LineDropped())
            {
                Destroy(_currentConnectionLine);
            }

            GlobalData.IsPointing = false;
            GlobalData.CanPoint = true;

            _currentConnectionLine = null;
            _currentOutputPointer = null;
        }
    }
}
