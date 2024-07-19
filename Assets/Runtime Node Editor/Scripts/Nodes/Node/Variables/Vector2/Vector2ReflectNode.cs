using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2ReflectNode : Node
    {
        public override void Execute()
        {
            Vector2 a = Vector2.zero;
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer inputA))
            {
                if (inputA.connectedOutputPointer)
                {
                    inputA.connectedOutputPointer.node.Execute();
                    a = PointerValue.GetVector2(inputA.connectedOutputPointer);
                }
            }

            Vector2 b = Vector2.zero;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer inputB))
            {
                if (inputB.connectedOutputPointer)
                {
                    inputB.connectedOutputPointer.node.Execute();
                    b = PointerValue.GetVector2(inputB.connectedOutputPointer);
                }
            }

            outputs[0].GetComponent<Vector2OutputPointer>().value = Vector2.Reflect(a, b);

            Elements.SetInputField(
                Elements.InputFields[0],
                outputs[0].GetComponent<Vector2OutputPointer>().value.x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1],
                outputs[0].GetComponent<Vector2OutputPointer>().value.y.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
            outputs[0].GetComponent<Vector2OutputPointer>().value = Vector2.zero;
        }
    }
}