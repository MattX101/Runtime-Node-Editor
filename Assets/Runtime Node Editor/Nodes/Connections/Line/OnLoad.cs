using RuntimeNodeEditor.Data;

namespace RuntimeNodeEditor.Node.Connection.Line
{
    internal partial class ConnectionLine
    {
        internal void OnLoad()
        {
            SetPositions();

            _startPosition *= CanvasData.ScalerFactor;
            _endPosition *= CanvasData.ScalerFactor;

            UpdatePoints();
        }
    }
}
