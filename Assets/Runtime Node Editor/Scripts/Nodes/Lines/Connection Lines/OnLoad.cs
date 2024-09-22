using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Lines
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
