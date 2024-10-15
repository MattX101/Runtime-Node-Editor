using RuntimeNodeEditor.Node.Connection.Data;
using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node.Connection.Lines
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

            if (!CheckPointerCompatibility(input.ValueTypeIndex, _currentOutputPointer.ValueTypeIndex))
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

        private bool CheckPointerCompatibility(int input, int output)
        {
            return input.Equals(output);
        }
    }
}
