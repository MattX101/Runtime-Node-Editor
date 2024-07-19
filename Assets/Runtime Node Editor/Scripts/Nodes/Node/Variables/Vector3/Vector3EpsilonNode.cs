using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3EpsilonNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<Vector3OutputPointer>().value = new Vector3(float.Epsilon, float.Epsilon, float.Epsilon);
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
