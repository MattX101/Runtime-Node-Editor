using RuntimeNodeEditor.Node.Connection.Line;
using RuntimeNodeEditor.Node.Connection.Data;
using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node.Connection.Lines
{
    public partial class ConnectionLines
    {
        public void Load(InputPointer input, OutputPointer output)
        {
            SetConnection(input, output);

            _currentConnectionLine = null;
        }

        public void UpdateLinesOnLoad()
        {
            foreach (ConnectionLine line in LinesData.DroppedLinesArray)
            {
                line.OnLoad();
                UpdateLineWidth(line);
            }
        }
    }
}
