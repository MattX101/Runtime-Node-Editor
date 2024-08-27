using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2EpsilonNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<Vector2OutputPointer>().value = new Vector2(float.Epsilon, float.Epsilon);
        }
    }
}
