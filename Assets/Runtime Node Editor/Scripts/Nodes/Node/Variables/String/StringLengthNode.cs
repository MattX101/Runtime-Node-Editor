using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringLengthNode : Node
    {
        public override void Execute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer valueInput))
                return;

            int length = 0;
            if (valueInput.connectedOutputPointer)
            {
                valueInput.connectedOutputPointer.node.Execute();
                length = PointerValue.GetString(valueInput.connectedOutputPointer).Length;
            }

            outputs[0].GetComponent<IntOutputPointer>().value = length;

            Elements.SetInputField(Elements.InputFields[0], length.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<IntOutputPointer>().Reset();
        }
    }
}