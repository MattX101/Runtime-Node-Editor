using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3MagnitudeNode : Node
    {
        public override void Execute()
        {
            Vector3 a = Vector3.zero;
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer inputA))
            {
                if (inputA.connectedOutputPointer)
                {
                    inputA.connectedOutputPointer.node.Execute();
                    a = PointerValue.GetVector3(inputA.connectedOutputPointer);
                }
            }

            outputs[0].GetComponent<FloatOutputPointer>().value = Vector3.SqrMagnitude(a);
            Elements.SetInputField(Elements.InputFields[0], a.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
            outputs[0].GetComponent<FloatOutputPointer>().value = 0.0f;
        }
    }
}