using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2LerpNode : Node
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

            float t = 0.5f;
            if (inputs[2].TryGetComponent(out SingleConnectionInputPointer inputT))
            {
                if (inputT.connectedOutputPointer)
                {
                    inputT.connectedOutputPointer.node.Execute();
                    t = PointerValue.GetFloat(inputT.connectedOutputPointer);
                }
            }

            outputs[0].GetComponent<Vector2OutputPointer>().value = Vector2.Lerp(a, b, t);

            Elements.SetInputField(
                Elements.InputFields[0],
                outputs[0].GetComponent<Vector2OutputPointer>().value.x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1],
                outputs[0].GetComponent<Vector2OutputPointer>().value.y.ToString());
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<Vector2OutputPointer>().value = Vector2.zero;
        }
    }
}