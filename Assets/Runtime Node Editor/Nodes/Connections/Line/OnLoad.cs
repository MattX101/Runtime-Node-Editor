using RuntimeNodeEditor.Data;

namespace RuntimeNodeEditor.Node.Connection.Line
{
    internal partial class ConnectionLine
    {
        internal void OnLoad()
        {
            SetPositions();

            _startPosition *= GlobalData.ScalerFactor;
            _endPosition *= GlobalData.ScalerFactor;

            UpdatePoints();
        }
    }
}
