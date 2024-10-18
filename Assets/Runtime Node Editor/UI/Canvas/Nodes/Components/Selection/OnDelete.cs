using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        internal static void Delete(RuntimeNodeEditor.Node.Node node, bool ignoreChecks = false)
        {
            if (!ignoreChecks)
            {
                if (CurrentNodeIsNull)
                    return;

                if (CanvasData.IsPointing || CanvasData.IsDragging || CanvasData.IsPanning || CanvasData.IsScrolling)
                    return;
            }

            node.DeletePointerConnections();

            Object.Destroy(node.gameObject);
            _currentNode = null;
        }
    }
}
