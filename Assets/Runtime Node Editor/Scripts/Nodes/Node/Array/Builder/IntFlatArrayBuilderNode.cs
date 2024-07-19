using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntFlatArrayBuilderNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out MultiConnectionInputPointer multiInput))
            {
                IntArrayOutputPointer outputArray = outputs[0].GetComponent<IntArrayOutputPointer>();
                outputArray.values = new int[multiInput.connectedOutputPointers.Count];

                for (int i = 0; i < multiInput.connectedOutputPointers.Count; i++)
                {
                    multiInput.connectedOutputPointers[i].node.Execute();

                    outputArray.values[i] = PointerValue.GetInt(multiInput.connectedOutputPointers[i]);
                    Debug.Log(outputArray.values[i]);
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
