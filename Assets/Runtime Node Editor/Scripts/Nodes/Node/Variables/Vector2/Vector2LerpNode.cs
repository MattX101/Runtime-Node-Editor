using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2LerpNode : Node
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

            float t = 0.5f;
            if (inputs[2].connectedOutputPointer)
            {
                inputs[2].connectedOutputPointer.node.Execute();
                t = inputs[2].connectedOutputPointer.Data.FloatValue;
            }

            outputs[0].Data.Vector2Value = Vector2.Lerp(a, b, t);

            Elements.SetInputField(
                Elements.InputFields[0],
                outputs[0].Data.Vector2Value.x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1],
                outputs[0].Data.Vector2Value.y.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
            outputs[0].Data.Vector2Value = Vector2.zero;
        }
    }
}