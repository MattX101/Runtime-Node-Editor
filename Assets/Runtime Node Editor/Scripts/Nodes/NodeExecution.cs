using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class NodeExecution : MonoBehaviour
    {
        public void Execute()
        {
            ExportNode[] exportNodes = FindObjectsOfType<ExportNode>();

            foreach (ExportNode exportNode in exportNodes)
                exportNode.Exectute();
        }
    }
}
