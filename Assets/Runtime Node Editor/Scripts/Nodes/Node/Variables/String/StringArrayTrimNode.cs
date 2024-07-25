using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringArrayTrimNode : Node
    {
        public readonly string[] trims =
        {
            "Base",
            "Start",
            "End",
        };

        public override void Execute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer toTrimInput))
                return;

            string toTrim = "";
            if (toTrimInput.connectedOutputPointer)
            {
                toTrimInput.connectedOutputPointer.node.Execute();
                toTrim = PointerValue.GetString(toTrimInput.connectedOutputPointer);
            }

            string result = toTrim;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer arrayTrimInput))
            {
                if (arrayTrimInput.connectedOutputPointer)
                {
                    arrayTrimInput.connectedOutputPointer.node.Execute();

                    switch (Elements.Dropdowns[0].Context)
                    {
                        case 0:
                            result = Trim(toTrim, arrayTrimInput.connectedOutputPointer.GetComponent<CharArrayOutputPointer>().values);
                            break;
                        case 1:
                            result = TrimStart(toTrim, arrayTrimInput.connectedOutputPointer.GetComponent<CharArrayOutputPointer>().values);
                            break;
                        case 2:
                            result = TrimEnd(toTrim, arrayTrimInput.connectedOutputPointer.GetComponent<CharArrayOutputPointer>().values);
                            break;
                        default:
                            break;
                    }
                }
            }

            outputs[0].GetComponent<StringOutputPointer>().value = result;

            Elements.SetInputField(Elements.InputFields[0], toTrim);
            Elements.SetInputField(Elements.InputFields[1], result);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }

        private string Trim(string value, char[] trim) { return value.Trim(trim); }
        private string TrimStart(string value, char[] trim) { return value.TrimStart(trim); }
        private string TrimEnd(string value, char[] trim) { return value.TrimEnd(trim); }
    }
}
