using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2MaxNode : Node
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
            
            outputs[0].Data.Vector2Value = Vector2.Max(a, b);

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