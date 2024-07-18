using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2MinNode : Node
    {
        public override void Execute()
        {
            Vector2 a = Vector2.zero;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                a = PointerValue.GetVector2(inputs[0].connectedOutputPointer);
            }

            Vector2 b = Vector2.zero;
            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                b = PointerValue.GetVector2(inputs[1].connectedOutputPointer);
            }

            outputs[0].Data.Vector2Value = Vector2.Min(a, b);

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