using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class CharFlatArrayOutputNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer input))
            {
                if (input.connectedOutputPointer)
                {
                    input.connectedOutputPointer.node.Execute();

                    foreach (char value in input.connectedOutputPointer.GetComponent<CharArrayOutputPointer>().values)
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
