using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3MaxNode : Node
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

            Vector3 b = Vector3.zero;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer inputB))
            {
                if (inputB.connectedOutputPointer)
                {
                    inputB.connectedOutputPointer.node.Execute();
                    b = PointerValue.GetVector3(inputB.connectedOutputPointer);
                }
            }

            outputs[0].GetComponent<Vector3OutputPointer>().value = Vector3.Max(a, b);

            Elements.SetInputField(
                Elements.InputFields[0],
                outputs[0].GetComponent<Vector3OutputPointer>().value.x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1],
                outputs[0].GetComponent<Vector3OutputPointer>().value.y.ToString());
            Elements.SetInputField(
                Elements.InputFields[2],
                outputs[0].GetComponent<Vector3OutputPointer>().value.z.ToString());
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<Vector3OutputPointer>().value = Vector3.zero;
        }
    }
}