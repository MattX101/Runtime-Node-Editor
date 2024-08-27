using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3EpsilonNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<Vector3OutputPointer>().value = new Vector3(float.Epsilon, float.Epsilon, float.Epsilon);
        }
    }
}
