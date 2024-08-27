using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringSubstringNode : Node
    {
        protected override void CodeToExecute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer valueInput))
                return;

            if (!valueInput.connectedOutputPointer)
                return;

            valueInput.connectedOutputPointer.node.Execute();
            string value = PointerValue.GetString(valueInput.connectedOutputPointer);

            int startIndex = 0;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer startIndexInput))
            {
                if (startIndexInput.connectedOutputPointer)
                {
                    startIndexInput.connectedOutputPointer.node.Execute();
                    startIndex = PointerValue.GetInt(startIndexInput.connectedOutputPointer);
                }
            }

            if (startIndex >= value.Length)
                startIndex = value.Length;

            int length = value.Length - startIndex;
            if (inputs[2].TryGetComponent(out SingleConnectionInputPointer lengthInput))
            {
                if (lengthInput.connectedOutputPointer)
                {
                    lengthInput.connectedOutputPointer.node.Execute();
                    length = PointerValue.GetInt(lengthInput.connectedOutputPointer);
                }
            }

            if (length > value.Length - startIndex)
                length = value.Length - startIndex;

            string substring = value.Substring(startIndex, length);

            outputs[0].GetComponent<StringOutputPointer>().value = substring;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], startIndex.ToString());
            Elements.SetInputField(Elements.InputFields[2], length.ToString());
            Elements.SetInputField(Elements.InputFields[3], substring);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}