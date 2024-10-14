using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Pointer : MonoBehaviour
    {
        public Node.Node Node
        {
            get;
            private set;
        }

        public int ValueTypeIndex
        {
            get;
            private set;
        }

        public Pointer(Node.Node node)
        {
            Node = node;
        }

        internal void AddInputPointer(Node.Node node, InputPointer input, int valueTypeIndex)
        {
            Node = node;
            ValueTypeIndex = valueTypeIndex;

            node.inputs.Add(input);
        }

        internal void AddOutputPointer(Node.Node node, OutputPointer output, int valueTypeIndex)
        {
            Node = node;
            ValueTypeIndex = valueTypeIndex;

            node.outputs.Add(output);
        }
    }
}
