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

        internal void AddInputPointer(Node node, InputPointer input, int valueTypeIndex)
        {
            Node = node;
            ValueTypeIndex = valueTypeIndex;

            node.inputs.Add(input);
        }

        internal void AddOutputPointer(Node node, OutputPointer output, int valueTypeIndex)
        {
            Node = node;
            ValueTypeIndex = valueTypeIndex;

            node.outputs.Add(output);
        }
    }
}
