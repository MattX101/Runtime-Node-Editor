using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3FlatArrayBuilderNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out MultiConnectionInputPointer multiInput))
            {
                Vector3ArrayOutputPointer outputArray = outputs[0].GetComponent<Vector3ArrayOutputPointer>();
                outputArray.values = new Vector3[multiInput.connectedOutputPointers.Count];

                for (int i = 0; i < multiInput.connectedOutputPointers.Count; i++)
                {
                    multiInput.connectedOutputPointers[i].node.Execute();

                    outputArray.values[i] = PointerValue.GetVector3(multiInput.connectedOutputPointers[i]);
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
