using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringReplaceNode : Node
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

            string replace = "";
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer toReplaceInput))
            {
                if (toReplaceInput.connectedOutputPointer)
                {
                    toReplaceInput.connectedOutputPointer.node.Execute();
                    replace = PointerValue.GetString(toReplaceInput.connectedOutputPointer);
                }
            }

            string result = value.Replace(value, replace);
            outputs[0].GetComponent<StringOutputPointer>().value = result;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], replace);
            Elements.SetInputField(Elements.InputFields[2], result);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}