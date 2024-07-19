using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringFlatArrayBuilderNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out MultiConnectionInputPointer multiInput))
            {
                StringArrayOutputPointer outputArray = outputs[0].GetComponent<StringArrayOutputPointer>();
                outputArray.values = new string[multiInput.connectedOutputPointers.Count];

                for (int i = 0; i < multiInput.connectedOutputPointers.Count; i++)
                {
                    multiInput.connectedOutputPointers[i].node.Execute();

                    outputArray.values[i] = PointerValue.GetString(multiInput.connectedOutputPointers[i]);
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
