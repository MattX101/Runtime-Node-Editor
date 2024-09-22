using RuntimeNodeEditor.Nodes.Pointer.Value;
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

        internal ValueType ValueType
        {
            get;
            private set;
        }

        public Pointer(Node.Node node)
        {
            Node = node;
        }

        internal void AddInputPointer(Node.Node node, InputPointer input, ValueType valueType)
        {
            Node = node;
            ValueType = valueType;

            node.inputs.Add(input);
        }

        internal void AddOutputPointer(Node.Node node, OutputPointer output, ValueType valueType)
        {
            Node = node;
            ValueType = valueType;

            node.outputs.Add(output);
        }
    }
}
