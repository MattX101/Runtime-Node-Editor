using UnityEngine;

namespace RuntimeNodeEditor.Node.Serialization
{
    public class NodesList : MonoBehaviour
    {
        [SerializeField]
        private NodesGroup _nodesGroups;
        public NodesGroup NodesGroup => _nodesGroups;
    }
}
