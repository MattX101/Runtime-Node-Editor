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

            if (nodeUI.Node.EndNode && factoryManager != null)
            {
                factoryManager.ExecutionNodeDeleted();
            }

            NodeDictionary.Nodes.Remove(nodeUI.gameObject.GetHashCode());
            nodeUI.Node.DeletePointerConnections();

            Object.Destroy(nodeUI.gameObject);
            SelectionData.currentActiveNodeUI = null;
        }
    }
}
