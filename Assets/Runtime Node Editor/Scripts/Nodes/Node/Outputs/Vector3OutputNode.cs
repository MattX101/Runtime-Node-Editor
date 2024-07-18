using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3OutputNode : Node
    {
        public override void Execute()
        {
            Vector3 v = Vector3.zero;

            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                v = PointerValue.GetVector3(inputs[0].connectedOutputPointer);
            }

            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                v.x = PointerValue.GetFloat(inputs[1].connectedOutputPointer);
            }
            if (inputs[2].connectedOutputPointer)
            {
                inputs[2].connectedOutputPointer.node.Execute();
                v.y = PointerValue.GetFloat(inputs[2].connectedOutputPointer);
            }
            if (inputs[3].connectedOutputPointer)
            {
                inputs[3].connectedOutputPointer.node.Execute();
                v.z = PointerValue.GetFloat(inputs[3].connectedOutputPointer);
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
