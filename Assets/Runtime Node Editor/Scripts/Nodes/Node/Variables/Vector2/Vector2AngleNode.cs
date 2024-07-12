using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2AngleNode : Node
    {
        public override void Execute()
        {
            Vector2 a = Vector2.zero;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                a = inputs[0].connectedOutputPointer.Data.Vector2Value;
            }

            Vector2 b = Vector2.zero;
            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                b = inputs[1].connectedOutputPointer.Data.Vector2Value;
            }

            outputs[0].Data.FloatValue = Vector2.Angle(a, b);

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