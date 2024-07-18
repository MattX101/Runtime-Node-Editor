using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3DistanceNode : Node
    {
        public override void Execute()
        {
            Vector3 a = Vector3.zero;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                a = PointerValue.GetVector3(inputs[0].connectedOutputPointer);
            }

            Vector3 b = Vector3.zero;
            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                b = PointerValue.GetVector3(inputs[1].connectedOutputPointer);
            }

            outputs[0].Data.FloatValue = Vector3.Distance(a, b);
            Elements.SetInputField(Elements.InputFields[0], outputs[0].Data.FloatValue.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
            outputs[0].Data.FloatValue = 0.0f;
        }
    }
}