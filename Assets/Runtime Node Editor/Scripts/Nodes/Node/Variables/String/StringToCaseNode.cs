using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringToCaseNode : Node
    {
        public readonly string[] cases =
        {
            "Lower",
            "Upper"
        };

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

            switch (Elements.Dropdowns[0].Context)
            {
                case 0:
                    value = ToLower(value);
                    break;
                case 1:
                    value = ToUpper(value);
                    break;
                default:
                    break;
            }

            outputs[0].GetComponent<StringOutputPointer>().value = value;

            Elements.SetInputField(Elements.InputFields[0], value);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }

        private string ToLower(string a) { return a.ToLower(); }
        private string ToUpper(string a) { return a.ToUpper(); }
    }
}
