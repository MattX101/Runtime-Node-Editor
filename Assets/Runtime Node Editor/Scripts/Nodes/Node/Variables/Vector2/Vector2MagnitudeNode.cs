using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2MagnitudeNode : Node
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

            outputs[0].GetComponent<FloatOutputPointer>().value = Vector2.SqrMagnitude(a);
            Elements.SetInputField(Elements.InputFields[0], outputs[0].GetComponent<FloatOutputPointer>().value.ToString());
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = 0.0f;
        }
    }
}