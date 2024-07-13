using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3MaxNode : Node
    {
        public override void Execute()
        {
            Vector3 a = Vector3.zero;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                a = inputs[0].connectedOutputPointer.Data.Vector3Value;
            }

            Vector3 b = Vector3.zero;
            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                b = inputs[1].connectedOutputPointer.Data.Vector3Value;
            }

            outputs[0].Data.Vector3Value = Vector3.Max(a, b);

            Elements.SetInputField(
                Elements.InputFields[0],
                outputs[0].Data.Vector3Value.x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1],
                outputs[0].Data.Vector3Value.y.ToString());
            Elements.SetInputField(
                Elements.InputFields[2],
                outputs[0].Data.Vector3Value.z.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
            outputs[0].Data.Vector3Value = Vector3.zero;
        }
    }
}