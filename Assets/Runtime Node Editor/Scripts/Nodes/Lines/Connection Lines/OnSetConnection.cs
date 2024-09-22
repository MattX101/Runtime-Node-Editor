using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Lines
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
