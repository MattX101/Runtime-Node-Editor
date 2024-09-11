using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Pointer : MonoBehaviour
    {
        private Node.Node _node;
        public Node.Node Node => _node;

        private ValueType _valueType = ValueType.None;
        internal ValueType ValueType => _valueType;

        public Pointer(Node.Node node)
        {
            _node = node;
        }

        internal void AddInputPointer(Node.Node node, InputPointer input, ValueType valueType)
        {
            _node = node;
            _valueType = valueType;

            node.inputs.Add(input);
        }

        internal void AddOutputPointer(Node.Node node, OutputPointer output, ValueType valueType)
        {
            _node = node;
            _valueType = valueType;

            node.outputs.Add(output);
        }
    }
}
