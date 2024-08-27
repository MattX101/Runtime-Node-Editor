using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2AngleNode : Node
    {
        protected override void CodeToExecute()
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

            outputs[0].GetComponent<FloatOutputPointer>().value = Vector2.Angle(a, b);
            Elements.SetInputField(Elements.InputFields[0], outputs[0].GetComponent<FloatOutputPointer>().value.ToString());
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = 0.0f;
        }
    }
}