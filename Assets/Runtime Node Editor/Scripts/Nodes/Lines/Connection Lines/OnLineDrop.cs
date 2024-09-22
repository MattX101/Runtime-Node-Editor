using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Lines
{
    public partial class ConnectionLines
    {
        private bool LineDropped()
        {
            if (!_raycastHit2D.collider)
                return false;

            _raycastHit2D.collider.TryGetComponent(out InputPointer input);

            if (!input)
                return false;

            if (!PointerValue.CheckCompatibility(input.ValueType, _currentOutputPointer.ValueType))
                return false;

            if (input.HasConnection)
                return false;

            DropOnInputPointer(input);

            LinesData.Add(_currentConnectionLine);
            _currentOutputPointer.Node.MoveUp();

            return true;
        }

        private void DropOnInputPointer(InputPointer input)
        {
            _currentOutputPointer.AddConnection(input);
            _currentConnectionLine.Input = input;

            SetInputConnection(input, _currentOutputPointer, _currentConnectionLine);
            input.Node.Reset();
        }
    }
}
