using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorFlatArrayBuilderNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].TryGetComponent(out MultiConnectionInputPointer multiInput))
            {
                ColorArrayOutputPointer outputArray = outputs[0].GetComponent<ColorArrayOutputPointer>();
                outputArray.values = new Color[multiInput.connectedOutputPointers.Count];

                for (int i = 0; i < multiInput.connectedOutputPointers.Count; i++)
                {
                    multiInput.connectedOutputPointers[i].node.Execute();

                    outputArray.values[i] = PointerValue.GetColor(multiInput.connectedOutputPointers[i]);
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
