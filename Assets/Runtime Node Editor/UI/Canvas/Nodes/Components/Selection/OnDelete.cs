using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        internal static void Delete(NodeUI nodeUI, bool ignoreChecks = false, Factory.FactoryManager factoryManager = null)
        {
            if (!ignoreChecks)
            {
                if (SelectionData.ActiveNodeUIIsNull)
                    return;

                if (GlobalData.IsPointing || GlobalData.IsDragging || GlobalData.IsPanning || GlobalData.IsScrolling)
                    return;
            }

            RuntimeNodeEditor.Node.Node node = nodeUI.GetComponent<RuntimeNodeEditor.Node.Node>();

            if (node.EndNode && factoryManager != null)
            {
                factoryManager.ExecutionNodeDeleted();
            }

            NodeList.Remove(nodeUI.gameObject.GetHashCode(), node);
            node.DeletePointerConnections();

            Object.Destroy(nodeUI.gameObject);
            SelectionData.currentActiveNodeUI = null;
        }
    }
}
