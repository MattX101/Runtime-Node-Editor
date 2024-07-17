using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2FlatArrayNode : Node
    {
        public override void Execute()
        {
            foreach (OutputPointer output in inputs[0].connectedOutputPointers)
            {
                output.node.Execute();
                Debug.Log(output.Data.Vector2Value);
            }

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
