using RuntimeNodeEditor.Node.Connection.Line;
using RuntimeNodeEditor.Node.Connection.Data;
using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node.Connection.Lines
{
    public partial class ConnectionLines
    {
        private void SetInputConnection(InputPointer Input, OutputPointer Output, ConnectionLine line)
        {
            Input.SetConnection(Output, line);
        }

        private void SetConnection(InputPointer Input, OutputPointer Output)
        {
            Output.AddConnection(Input);
            Create(Output);

            SetInputConnection(Input, Output, _currentConnectionLine);

            _currentConnectionLine.Input = Input;
            LinesData.Add(_currentConnectionLine);
        }
    }
}
