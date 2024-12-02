using RuntimeNodeEditor.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        internal static void Delete(NodeUI node, bool ignoreChecks = false)
        {
            if (!ignoreChecks)
            {
                if (CurrentNodeIsNull)
                    return;

                if (GlobalData.IsPointing || GlobalData.IsDragging || GlobalData.IsPanning || GlobalData.IsScrolling)
                    return;
            }

            node.GetComponent<RuntimeNodeEditor.Node.Node>().DeletePointerConnections();

            Object.Destroy(node.gameObject);
            _currentNode = null;
        }
    }
}
