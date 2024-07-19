using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatFlatArrayOutputNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer input))
            {
                if (input.connectedOutputPointer)
                {
                    input.connectedOutputPointer.node.Execute();

                    foreach (float value in input.connectedOutputPointer.GetComponent<FloatArrayOutputPointer>().values)
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
