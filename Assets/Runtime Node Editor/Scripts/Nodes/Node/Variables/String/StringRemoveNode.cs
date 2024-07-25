using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringRemoveNode : Node
    {
        public override void Execute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer valueInput))
                return;

            string value = "";
            if (valueInput.connectedOutputPointer)
            {
                valueInput.connectedOutputPointer.node.Execute();
                value = PointerValue.GetString(valueInput.connectedOutputPointer);
            }

            int startIndex = 0;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer startIndexInput))
            {
                if (startIndexInput.connectedOutputPointer)
                {
                    startIndexInput.connectedOutputPointer.node.Execute();
                    startIndex = PointerValue.GetInt(startIndexInput.connectedOutputPointer);
                }
            }

            int count = 1;
            if (inputs[2].TryGetComponent(out SingleConnectionInputPointer countInput))
            {
                if (countInput.connectedOutputPointer)
                {
                    countInput.connectedOutputPointer.node.Execute();
                    count = PointerValue.GetInt(countInput.connectedOutputPointer);
                }
            }

            string result = value.Remove(startIndex, count);
            outputs[0].GetComponent<StringOutputPointer>().value = result;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], startIndex.ToString());
            Elements.SetInputField(Elements.InputFields[2], count.ToString());
            Elements.SetInputField(Elements.InputFields[3], result);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}