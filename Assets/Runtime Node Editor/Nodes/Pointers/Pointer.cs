using UnityEngine;

namespace RuntimeNodeEditor.Node.Pointer
{
    public class Pointer : MonoBehaviour
    {
        public Node Node
        {
            get;
            private set;
        }

        public int ValueTypeIndex
        {
            get;
            private set;
        }

        public Pointer(Node node)
        {
            Node = node;
        }

        internal void AddInputPointer(Node node, InputPointer Input, int valueTypeIndex)
        {
            Node = node;
            ValueTypeIndex = valueTypeIndex;

            node.Inputs.Add(Input);
        }

        internal void AddOutputPointer(Node node, OutputPointer Output, int valueTypeIndex)
        {
            Node = node;
            ValueTypeIndex = valueTypeIndex;

            node.Outputs.Add(Output);
        }
    }
}
