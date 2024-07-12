using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2MagnitudeNode : Node
    {
        public override void Execute()
        {
            Vector2 a = Vector2.zero;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                a = inputs[0].connectedOutputPointer.Data.Vector2Value;
            }
            
            outputs[0].Data.FloatValue = Vector2.SqrMagnitude(a);

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