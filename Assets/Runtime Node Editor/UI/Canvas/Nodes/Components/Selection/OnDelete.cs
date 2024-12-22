using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        internal static void Delete(NodeUI nodeUI, bool ignoreChecks = false)
        {
            if (!ignoreChecks)
            {
                if (CurrentNodeIsNull)
                    return;

                if (GlobalData.IsPointing || GlobalData.IsDragging || GlobalData.IsPanning || GlobalData.IsScrolling)
                    return;
            }

            RuntimeNodeEditor.Node.Node node = nodeUI.GetComponent<RuntimeNodeEditor.Node.Node>();
            NodeList.Remove(nodeUI.gameObject.GetHashCode(), node);
            node.DeletePointerConnections();

            Object.Destroy(nodeUI.gameObject);
            _currentNode = null;
        }
    }
}
