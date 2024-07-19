using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2OutputNode : Node
    {
        public override void Execute()
        {
            Vector2 v = Vector2.zero;

            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer inputV))
            {
                if (inputV.connectedOutputPointer)
                {
                    inputV.connectedOutputPointer.node.Execute();
                    v = PointerValue.GetVector2(inputV.connectedOutputPointer);
                }
            }

            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer inputX))
            {
                if (inputX.connectedOutputPointer)
                {
                    inputX.connectedOutputPointer.node.Execute();
                    v.x = PointerValue.GetFloat(inputX.connectedOutputPointer);
                }
            }
            if (inputs[2].TryGetComponent(out SingleConnectionInputPointer inputY))
            {
                if (inputY.connectedOutputPointer)
                {
                    inputY.connectedOutputPointer.node.Execute();
                    v.y = PointerValue.GetFloat(inputY.connectedOutputPointer);
                }
            }

            Elements.SetInputField(
                Elements.InputFields[0], 
                v.x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1], 
                v.y.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
