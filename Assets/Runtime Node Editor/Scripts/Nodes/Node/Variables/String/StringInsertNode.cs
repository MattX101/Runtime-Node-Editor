using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringInsertNode : Node
    {
        protected override void CodeToExecute()
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

            string insert = "";
            if (inputs[2].TryGetComponent(out SingleConnectionInputPointer insertInput))
            {
                if (insertInput.connectedOutputPointer)
                {
                    insertInput.connectedOutputPointer.node.Execute();
                    insert = PointerValue.GetString(insertInput.connectedOutputPointer);
                }
            }

            string result = value.Insert(startIndex, insert);
            outputs[0].GetComponent<StringOutputPointer>().value = result;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], startIndex.ToString());
            Elements.SetInputField(Elements.InputFields[2], insert);
            Elements.SetInputField(Elements.InputFields[3], result);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}