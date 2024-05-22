using UnityEngine;

namespace RuntimeNodeEditor.Node.Pointer
{
    public class Pointer : MonoBehaviour
    {
        public Node node;

        public ValueType valueType = ValueType.None;

        public Pointer(string name, Node node)
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
