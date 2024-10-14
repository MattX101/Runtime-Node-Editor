using RuntimeNodeEditor.Node.Line;
using RuntimeNodeEditor.Node.Lines.Data;
using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node.Lines
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
