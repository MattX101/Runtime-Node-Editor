using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Pointer : MonoBehaviour
    {
        public Node.Node node;
        
        public ValueType valueType = ValueType.None;

        public Pointer(Node.Node node)
        {
            this.node = node;
        }

        public virtual void Reset()
        {
            //
        }
    }
}
