using UnityEngine;

namespace RuntimeNodeEditor.UI.Tooltip
{
    internal class NewFileManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject nodesObject;

        [SerializeField]
        private Window.OnCanvasClearWindow onOpenWindow;

        public void Clear()
        {
            Node.Node[] nodes = nodesObject.GetComponentsInChildren<Node.Node>();

            if (nodes.Length > 0)
            {
                onOpenWindow.Create();

                return;
            }

            onOpenWindow.Clear();
        }
    }
}
