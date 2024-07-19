using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3OutputNode : Node
    {
        public override void Execute()
        {
            Vector3 v = Vector3.zero;

            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer inputV))
            {
                if (inputV.connectedOutputPointer)
                {
                    inputV.connectedOutputPointer.node.Execute();
                    v = PointerValue.GetVector3(inputV.connectedOutputPointer);
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
            if (inputs[3].TryGetComponent(out SingleConnectionInputPointer inputZ))
            {
                if (inputZ.connectedOutputPointer)
                {
                    inputZ.connectedOutputPointer.node.Execute();
                    v.z = PointerValue.GetFloat(inputZ.connectedOutputPointer);
                }
            }

            Elements.SetInputField(
                Elements.InputFields[0],
                v.x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1],
                v.y.ToString());
            Elements.SetInputField(
                Elements.InputFields[2],
                v.z.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
