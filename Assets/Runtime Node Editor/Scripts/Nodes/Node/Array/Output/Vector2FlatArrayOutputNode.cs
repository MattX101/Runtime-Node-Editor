using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2FlatArrayOutputNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer input))
            {
                if (input.connectedOutputPointer)
                {
                    input.connectedOutputPointer.node.Execute();

                    foreach (Vector2 value in input.connectedOutputPointer.GetComponent<Vector2ArrayOutputPointer>().values)
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
