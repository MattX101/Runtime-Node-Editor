using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringTrimNode : Node
    {
        public readonly string[] trims =
        {
            "Base",
            "Start",
            "End",
        };

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

            char trim = ' ';
            string result = value;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer trimInput))
            {
                if (trimInput.connectedOutputPointer)
                {
                    trimInput.connectedOutputPointer.node.Execute();
                    trim = PointerValue.GetChar(trimInput.connectedOutputPointer);

                    switch (Elements.Dropdowns[0].Context)
                    {
                        case 0:
                            result = Trim(value, PointerValue.GetChar(trimInput.connectedOutputPointer));
                            break;
                        case 1:
                            result = TrimStart(value, PointerValue.GetChar(trimInput.connectedOutputPointer));
                            break;
                        case 2:
                            result = TrimEnd(value, PointerValue.GetChar(trimInput.connectedOutputPointer));
                            break;
                        default:
                            break;
                    }
                }
            }

            outputs[0].GetComponent<StringOutputPointer>().value = result;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], trim.ToString());
            Elements.SetInputField(Elements.InputFields[2], result);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }

        private string Trim(string value, char trim) { return value.Trim(trim); }
        private string TrimStart(string value, char trim) { return value.TrimStart(trim); }
        private string TrimEnd(string value, char trim) { return value.TrimEnd(trim); }
    }
}
