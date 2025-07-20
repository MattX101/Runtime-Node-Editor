using UnityEngine;

namespace RuntimeNodeEditor.Node.Pointer
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        public Node Node
        {
            get => _node;
        }

        public int ValueTypeIndex
        {
            get;
            protected set;
        }

        internal void AddInputPointer(Node node, InputPointer Input, int valueTypeIndex)
        {
            ValueTypeIndex = valueTypeIndex;

            node.Inputs.Add(Input);
        }

        internal void AddOutputPointer(Node node, OutputPointer Output, int valueTypeIndex)
        {
            ValueTypeIndex = valueTypeIndex;

            node.Outputs.Add(Output);
        }
    }
}
