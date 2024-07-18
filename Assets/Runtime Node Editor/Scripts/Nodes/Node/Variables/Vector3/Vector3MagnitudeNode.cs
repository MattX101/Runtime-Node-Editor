using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3MagnitudeNode : Node
    {
        public override void Execute()
        {
            Vector3 a = Vector3.zero;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                a = PointerValue.GetVector3(inputs[0].connectedOutputPointer);
            }
            
            outputs[0].Data.FloatValue = Vector3.SqrMagnitude(a);
            Elements.SetInputField(Elements.InputFields[0], a.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
            outputs[0].Data.FloatValue = 0.0f;
        }
    }
}