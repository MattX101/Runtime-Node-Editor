using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2EpsilonNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<Vector2OutputPointer>().value = new Vector2(float.Epsilon, float.Epsilon);
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
