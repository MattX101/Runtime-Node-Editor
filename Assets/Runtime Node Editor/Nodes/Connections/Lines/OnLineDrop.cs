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

            _raycastHit2D.collider.TryGetComponent(out InputPointer Input);

            if (!Input)
                return false;

            if (!CheckPointerCompatibility(Input.ValueTypeIndex, _currentOutputPointer.ValueTypeIndex))
                return false;

            if (Input.HasConnection)
                return false;

            DropOnInputPointer(Input);

            LinesData.Add(_currentConnectionLine);
            _currentOutputPointer.Node.ResetAndExecute();

            return true;
        }

        private void DropOnInputPointer(InputPointer Input)
        {
            _currentOutputPointer.AddConnection(Input);
            _currentConnectionLine.Input = Input;

            SetInputConnection(Input, _currentOutputPointer, _currentConnectionLine);
            Input.Node.Reset();
            Input.DisableUIElement();
        }

        private bool CheckPointerCompatibility(int Input, int Output)
        {
            return Input.Equals(Output);
        }
    }
}
