using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Node.Connection.Lines;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static partial class Selection
    {
        internal static void OnUpdate(NodeUIManager nodeUIManager, ConnectionLines connectionLines)
        {
            MangeSelection();
            KeyboardInput(nodeUIManager, connectionLines);
        }

        private static void MangeSelection()
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0))
                return;

            RaycastHit2D hit2D = Physics2D.Raycast(
                MouseController.MouseWorldPosition,
                Vector2.zero
                );

            if (hit2D.collider)
            {
                hit2D.collider.TryGetComponent(out NodeUI node);
                if (!node)
                    return;

                Select(node);

                return;
            }

            Deselect();
        }

        private static void KeyboardInput(NodeUIManager nodeUIManager, ConnectionLines connectionLines)
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftControl))
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.C))
                {
                    Copy(false);
                }
                else if (UnityEngine.Input.GetKeyDown(KeyCode.X))
                {
                    Copy(true);
                }
                else if (UnityEngine.Input.GetKeyDown(KeyCode.V))
                {
                    Paste(nodeUIManager, connectionLines);
                }
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
            {
                Delete(SelectionData.currentActiveNodeUI, false, nodeUIManager.FactoryManager);
            }
        }
    }
}
