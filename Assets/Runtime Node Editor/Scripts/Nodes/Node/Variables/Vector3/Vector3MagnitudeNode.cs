using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3MagnitudeNode : Node
    {
        protected override void CodeToExecute()
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
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = 0.0f;
        }
    }
}