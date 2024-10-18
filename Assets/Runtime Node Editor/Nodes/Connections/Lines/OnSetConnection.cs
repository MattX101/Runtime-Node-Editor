using RuntimeNodeEditor.Node.Connection.Line;
using RuntimeNodeEditor.Node.Connection.Data;
using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node.Connection.Lines
{
    public partial class ConnectionLines
    {
        private void SetInputConnection(InputPointer input, OutputPointer output, ConnectionLine line)
        {
            input.SetConnection(output, line);
        }

        private void SetConnection(InputPointer input, OutputPointer output)
        {
            output.AddConnection(input);
            Create(output);

            SetInputConnection(input, output, _currentConnectionLine);

            _currentConnectionLine.Input = input;
            LinesData.Add(_currentConnectionLine);
        }
    }
}
