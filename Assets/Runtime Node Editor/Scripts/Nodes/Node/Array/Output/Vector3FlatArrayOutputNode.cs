using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3FlatArrayOutputNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer input))
            {
                if (input.connectedOutputPointer)
                {
                    input.connectedOutputPointer.node.Execute();

                    foreach (Vector3 value in input.connectedOutputPointer.GetComponent<Vector3ArrayOutputPointer>().values)
                        Debug.Log(value);
                }
            }

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
