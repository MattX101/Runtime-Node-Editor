using RuntimeNodeEditor.Nodes.Pointer.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class Pointer : MonoBehaviour
    {
        public Node.Node node;
        
        public ValueType valueType = ValueType.None;

        public Pointer(string name, Node.Node node)
        {
            this.name = name;
            this.node = node;
        }

        public virtual void Reset()
        {
            //
        }
    }
}
