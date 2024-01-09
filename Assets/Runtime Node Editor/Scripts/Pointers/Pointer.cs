using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode.Pointer
{
    public class Pointer : MonoBehaviour
    {
        public string name;

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
