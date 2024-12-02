using UnityEngine;
using System;

namespace RuntimeNodeEditor.Node.Serialization
{
    [Serializable]
    public class NodesGroup
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private NodesGroup[] nodesGroups;

        [SerializeField]
        private GameObject[] nodePrefabs;

        public NodesGroup GetGroup(int index)
        {
            return nodesGroups[index];
        }

        public GameObject GetNode(int index)
        {
            return nodePrefabs[index];
        }
    }
}
