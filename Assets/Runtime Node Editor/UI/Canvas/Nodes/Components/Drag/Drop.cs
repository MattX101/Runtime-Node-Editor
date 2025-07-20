using RuntimeNodeEditor.Data;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    public static partial class Drag
    {
        private static void ValidateDrop()
        {
            if (_selectedNodeUI)
            {
                Drop();
            }

            Reset();
        }

        private static void Drop()
        {
            _dragOnSpawn = false;
            GlobalData.IsDragging = false;

            _selectedNodeUI = null;
        }

        private static void Reset()
        {
            _selectedNodeUI = null;
            _dragOnSpawn = false;
        }
    }
}
